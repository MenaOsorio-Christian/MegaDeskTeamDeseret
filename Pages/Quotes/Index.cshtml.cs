using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MegaDeskTeamDeseret.Models;
using System.Linq;

namespace MegaDeskTeamDeseret.Pages.Quotes
{
    public class IndexModel : PageModel
    {
        private readonly MegaDeskTeamDeseret.Models.MegaDeskTeamDeseretContext _context;

        public IndexModel(MegaDeskTeamDeseret.Models.MegaDeskTeamDeseretContext context)
        {
            _context = context;
        }

        //search
        public IList<Quote> Quote { get;set; }
        [BindProperty(SupportsGet = true)]
        public string CurrentFilter { get; set; }
        public SelectList LastName { get; set; }

        //sort last name or by date
        public string NameSort { get; set;}
        public string DateSort { get; set;}
   

        public async Task OnGetAsync(string sortOrder, string searchString) 
        {
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            CurrentFilter = searchString;
           
            IQueryable<Quote> quotesIQ = from m in  _context.Quote
                                         select m;
            if (!String.IsNullOrEmpty(searchString))
            {
                quotesIQ = quotesIQ.Where(m => m.LastName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    quotesIQ = quotesIQ.OrderByDescending(m => m.LastName);
                    break;
                case "Date":
                    quotesIQ = quotesIQ.OrderBy(m => m.SubmitedDate);
                    break;
                case "date_desc":
                    quotesIQ = quotesIQ.OrderByDescending(m => m.SubmitedDate);
                    break;
                default:
                    quotesIQ = quotesIQ.OrderBy(m => m.LastName);
                    break;
            }

            Quote = await quotesIQ.AsNoTracking().ToListAsync();
        }
    }
}
