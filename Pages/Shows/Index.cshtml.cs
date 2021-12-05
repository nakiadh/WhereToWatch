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
    public class IndexModel : PageModel
    {
        private readonly WhereToWatch.Models.Context _context;

        public IndexModel(WhereToWatch.Models.Context context)
        {
            _context = context;
        }

        public IList<Show> Show { get;set; }

        public async Task OnGetAsync()
        {
            Show = await _context.Show.ToListAsync();
        }
    }
}
