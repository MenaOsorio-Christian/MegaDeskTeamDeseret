using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MegaDeskTeamDeseret.Models
{
    public class Quote
    {
        public int ID { get; set; }

        [Display(Name = "First Name")]
        [StringLength(100, MinimumLength = 3)]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(100, MinimumLength = 3)]
        [Required]
        public string LastName { get; set; }

        [Display(Name = "Desk Width")]
        [Range(23, 96)]
        [Required]
        public int DeskWidth { get; set; }

        [Display(Name = "Desk Depth")]
        [Range(11, 48)]
        [Required]
        public int DeskDepth { get; set; }

        [Display(Name = "Number of Drawers")]
        [Range(0, 7)]
        public int NumberOfDrawers { get; set; }

        [Display(Name = "Surface Material")]
        public string SurfaceMaterial { get; set; }

        public double Area { get; set; }

        [Display(Name = "Rush Days")]
        public int RushDays { get; set; }

        [DataType(DataType.Date)]
        public DateTime SubmitedDate { get; set; }

        [Display(Name ="Price of Desk")]
        public double Price { get; set; }

        // variables to calculate price
        public double MaterialCost;
        public double BasePrice = 200;
        public double DrawerCost;
        public double ExtraSurfaceAreaCost = 0;
        public double ShippingCost;
       


    }
}
