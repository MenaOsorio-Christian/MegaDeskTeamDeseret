using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MegaDeskTeamDeseret.Models;

namespace MegaDeskTeamDeseret.Pages.Quotes
{
    public class IndexModel : PageModel
    {
        private readonly MegaDeskTeamDeseret.Models.MegaDeskTeamDeseretContext _context;

        public IndexModel(MegaDeskTeamDeseret.Models.MegaDeskTeamDeseretContext context)
        {
            _context = context;
        }

        public IList<Quote> Quote { get;set; }

        public async Task OnGetAsync()
        {
            Quote = await _context.Quote.ToListAsync();
        }
    }
}
