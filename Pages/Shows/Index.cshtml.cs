using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WhereToWatch.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;


namespace WhereToWatch.Pages.Shows
{
    public class IndexModel : PageModel
    {
        private readonly WhereToWatch.Models.Context _context;
        private readonly IConfiguration Configuration;

        public IndexModel(WhereToWatch.Models.Context context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }


        
        public PaginatedList<Show> Show { get;set; } 
        public IList<Service> Service {get; set;}

        public string TitleSortAsc {get; set;}
        public string DateSortAsc {get; set;}
        public string CurrentFilter {get; set;}

        [BindProperty(SupportsGet = true)]
        public string CurrentSort {get; set;}
        
        //public SelectList SortList {get; set;}
        
        [BindProperty(SupportsGet = true)]
        public string SearchString {get; set;}



        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex)
        {
            
            CurrentSort = sortOrder;
            TitleSortAsc = String.IsNullOrEmpty(sortOrder) ? "title_asc" : "";
            DateSortAsc = sortOrder == "Date" ? "date_asc" : "Date";
            

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Show> shows = from s in _context.Show
                                    select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                shows = shows.Where(s => s.Title.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "title_asc":
                    shows = shows.OrderBy(s => s.Title);
                    break;
                case "date_asc":
                    shows = shows.OrderBy(s => s.ReleaseDate);
                    break;
            }

            var pageSize = Configuration.GetValue("PageSize", 4);
            Show = await PaginatedList<Show>.CreateAsync(shows.Include(s => s.ShowService).ThenInclude(ss => ss.Service).AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}    
