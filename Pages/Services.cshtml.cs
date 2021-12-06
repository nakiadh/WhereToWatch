using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WhereToWatch.Models;
using Microsoft.Extensions.Logging;

namespace WhereToWatch.Pages
{
    public class ServicesModel : PageModel
    {
        private readonly WhereToWatch.Models.Context _context;

        public ServicesModel(WhereToWatch.Models.Context context)
        {
            _context = context;
        }

        public IList<Service> Service { get;set; }
        public IList<Show> Show {get; set;}
        public IList<ShowService> ShowService {get; set;}

        public async Task OnGetAsync()
        {
            Service = await _context.Service.Include(s => s.ShowService).ThenInclude(ss => ss.Show).ToListAsync();
        }
    }
}
