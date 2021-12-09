using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WhereToWatch.Models;
using Microsoft.Extensions.Logging;

namespace WhereToWatch.Pages.Shows
{
    public class EditModel : PageModel
    {
        private readonly WhereToWatch.Models.Context _context;
        private readonly ILogger _logger;

        public EditModel(WhereToWatch.Models.Context context, ILogger<EditModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        [BindProperty]
        public Show Show { get; set; }

        public List<Service> Services {get; set;}

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Show = await _context.Show.Include(s => s.ShowService).ThenInclude(ss => ss.Service).FirstOrDefaultAsync(m => m.ShowId == id);
            Services = _context.Service.ToList();

            if (Show == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int[] selectedService)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //_context.Attach(Show).State = EntityState.Modified;
            var showToUpdate = await _context.Show.Include(s => s.ShowService).ThenInclude(ss => ss.Service).FirstOrDefaultAsync(m => m.ShowId == Show.ShowId);
            showToUpdate.Title = Show.Title;
            showToUpdate.ReleaseDate = Show.ReleaseDate;
            showToUpdate.Type = Show.Type;
            showToUpdate.Genre = Show.Genre;
            showToUpdate.Rating = Show.Rating;

            UpdateShowService(selectedService, showToUpdate);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShowExists(Show.ShowId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ShowExists(int id)
        {
            return _context.Show.Any(e => e.ShowId == id);
        }

        private void UpdateShowService(int[] selectedService, Show showToUpdate)
        {
            if (selectedService == null)
            {
                showToUpdate.ShowService = new List<ShowService>();
                return;
            }

            List<int> currentServices = showToUpdate.ShowService.Select(c => c.ServiceId).ToList();
            List<int> selectedServicesList = selectedService.ToList();

            foreach (var service in _context.Service)
            {
                if (selectedServicesList.Contains(service.ServiceId))
                {
                    if (!currentServices.Contains(service.ServiceId))
                    {
                        showToUpdate.ShowService.Add(
                            new ShowService { ShowId = showToUpdate.ShowId, ServiceId = service.ServiceId }
                        );
                    _logger.LogWarning($"Show {showToUpdate.Title} - ADD {service.Name}");
                    }
                }
                else
                {
                    if (currentServices.Contains(service.ServiceId))
                    {
                        ShowService serviceToRemove = showToUpdate.ShowService.SingleOrDefault(s => s.ServiceId == service.ServiceId);
                        _context.Remove(serviceToRemove);
                        _logger.LogWarning($"Show {showToUpdate.Title} removed from {service.Name}");
                    }
                }
            }
        }
    }
}
