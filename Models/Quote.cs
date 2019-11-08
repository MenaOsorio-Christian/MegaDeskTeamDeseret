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
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public int DeskWidth { get; set; }

        public int DeskDepth { get; set; }

        [Display(Name = "Number Of Drawers")]
        public int NumberOfDrawers { get; set; }

        [Display(Name = "Surface Material")]
        public string SurfaceMaterial { get; set; }

        [Display(Name = "Rush Days")]
        public int RushDays { get; set; }

        [DataType(DataType.Date)]
        public DateTime SubmitedDate { get; set; }

    }
}
