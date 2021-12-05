using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WhereToWatch.Models;

namespace WhereToWatch.Pages.Shows
{
    public class DetailsModel : PageModel
    {
        private readonly WhereToWatch.Models.Context _context;

        public DetailsModel(WhereToWatch.Models.Context context)
        {
            _context = context;
        }

        public Show Show { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Show = await _context.Show.FirstOrDefaultAsync(m => m.ShowId == id);

            if (Show == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
