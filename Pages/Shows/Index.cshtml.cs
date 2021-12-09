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

        //[BindProperty(SupportsGet = true)]
        //public int PageNum {get; set;} = 1;
        //public int PageSize {get; set;} = 10;

        public string TitleSortAsc {get; set;}
        public string TitleSortDesc {get; set;}
        public string DateSortAsc {get; set;}
        public string DateSortDesc {get; set;}
        public string CurrentFilter {get; set;}

        [BindProperty(SupportsGet = true)]
        public string CurrentSort {get; set;}
        
        public SelectList SortList {get; set;}
        
        [BindProperty(SupportsGet = true)]
        public string SearchString {get; set;}



        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex)
        {
            
            CurrentSort = sortOrder;
            TitleSortAsc = String.IsNullOrEmpty(sortOrder) ? "title_asc" : "";
           // TitleSortDesc = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            DateSortAsc = sortOrder == "Date" ? "date_asc" : "Date";
            //DateSortDesc = sortOrder == "Date" ? "date_desc" : "Date";
            

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
                /* case "title_desc":
                    shows = shows.OrderByDescending(s => s.Title);
                    break; */
                case "date_asc":
                    shows = shows.OrderBy(s => s.ReleaseDate);
                    break;
                /* case "date_desc":
                    shows = shows.OrderByDescending(s => s.ReleaseDate);
                    break; */
            }


            /* var shows = from x in _context.Show
                select x;
            if (!string.IsNullOrEmpty(SearchString))
            {
                shows = shows.Where(m => m.Title.Contains(SearchString));
            }
            

            var query = _context.Show.Select(s => s);
            List<SelectListItem> sortItems = new List<SelectListItem> {
                new SelectListItem { Text = "Title Ascending", Value = "title_asc"},
                new SelectListItem { Text = "Title Descending", Value = "title_desc"},
                new SelectListItem { Text = "Release Date Ascending", Value = "date_asc"},
                new SelectListItem { Text = "Release Date Descending", Value = "date_desc"}
            };
            SortList = new SelectList(sortItems, "Value", "Text", CurrentSort);

            switch (CurrentSort)
            {
                case "title_asc":
                    query = query.OrderBy(s => s.Title);
                    break;

                case "title_desc":
                    query = query.OrderByDescending(s => s.Title);
                    break;

                case "date_asc":
                    query = query.OrderBy(s => s.ReleaseDate);
                    break;

                case "date_desc":
                    query = query.OrderByDescending(s => s.ReleaseDate);
                    break;
            } */
            /* Show = await shows.ToListAsync();
            Show = await _context.Show.Include(s => s.ShowService).ThenInclude(ss => ss.Service).ToListAsync();
            Show = await query.Skip((PageNum-1)*PageSize).Take(PageSize).ToListAsync(); */

            var pageSize = Configuration.GetValue("PageSize", 4);
            Show = await PaginatedList<Show>.CreateAsync(shows.Include(s => s.ShowService).ThenInclude(ss => ss.Service).AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}    
