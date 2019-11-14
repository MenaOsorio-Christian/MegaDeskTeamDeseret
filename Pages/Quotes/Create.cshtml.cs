using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MegaDeskTeamDeseret.Models;

namespace MegaDeskTeamDeseret.Pages.Quotes
{
    public class CreateModel : PageModel
    {
        private readonly MegaDeskTeamDeseret.Models.MegaDeskTeamDeseretContext _context;

        public CreateModel(MegaDeskTeamDeseret.Models.MegaDeskTeamDeseretContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Quote Quote { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Quote.DrawerCost = Quote.NumberOfDrawers * 50;
            getArea();
            GetMaterialCost();
            getExtraSurfaceAreaCost();
            getAddtionalRushCost();
            getPrice();

            _context.Quote.Add(Quote);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        private void getPrice()
        {
            Quote.Price = Quote.DrawerCost + Quote.MaterialCost + Quote.BasePrice + Quote.ExtraSurfaceAreaCost + Quote.ShippingCost;
        }

        public void getDrawerCost()
        {
            Quote.DrawerCost = Quote.NumberOfDrawers * 50;
        }

    
        public void getArea()
        {
            Quote.Area = Quote.DeskWidth * Quote.DeskDepth;
        }

        public void GetMaterialCost()
        {
           switch (Quote.SurfaceMaterial)
            {
                case "Rosewood":
                    if (Quote.SurfaceMaterial == "Rosewood")
                    {
                        Quote.MaterialCost = 300;
                    }
                    break;
                case "Oak":
                    if (Quote.SurfaceMaterial == "Oak")
                    {
                        Quote.MaterialCost = 200;
                    }
                    break;
                case "Veneer":
                    if (Quote.SurfaceMaterial == "Veneer")
                    {
                        Quote.MaterialCost = 125;
                    }
                    break;
                case "Laminate":
                    if (Quote.SurfaceMaterial == "Laminate")
                    {
                        Quote.MaterialCost = 150;
                    }
                    break;
                case "Pine":
                    if (Quote.SurfaceMaterial == "Pine")
                    {
                        Quote.MaterialCost = 50;
                    }
                    break;
            }
        }

        public void getAddtionalRushCost()
        {
            switch (Quote.ShippingCost)
            {
                case 3:
                    if (Quote.Area < 1000)
                    {
                        Quote.ShippingCost = 60;
                    }

                    if (Quote.Area < 2000 && Quote.Area > 1000)
                    {
                        Quote.ShippingCost = 70;
                    }

                    if (Quote.Area > 2000)
                    {
                        Quote.ShippingCost = 80;
                    }
                    break;

                case 5:
                    if (Quote.Area < 1000)
                    {
                        Quote.ShippingCost = 40;
                    }

                    if (Quote.Area < 2000 && Quote.Area > 1000)
                    {
                        Quote.ShippingCost = 50;
                    }

                    if (Quote.Area > 2000)
                    {
                        Quote.ShippingCost = 60;
                    }
                    break;

                case 7:
                    if (Quote.Area < 1000)
                    {
                        Quote.ShippingCost = 30;
                    }

                    if (Quote.Area < 2000 && Quote.Area > 1000)
                    {
                        Quote.ShippingCost = 35;
                    }

                    if (Quote.Area > 2000)
                    {
                        Quote.ShippingCost = 40;
                    }
                    break;
            }

        }

        public void getExtraSurfaceAreaCost()
        {
            if (Quote.Area > 1000)
            {
                Quote.ExtraSurfaceAreaCost = Quote.Area - 1000;
            }
        }
    }
}
