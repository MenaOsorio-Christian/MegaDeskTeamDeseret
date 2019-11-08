using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MegaDeskTeamDeseret.Models
{
    public class MegaDeskTeamDeseretContext : DbContext
    {
        public MegaDeskTeamDeseretContext (DbContextOptions<MegaDeskTeamDeseretContext> options)
            : base(options)
        {
        }

        public DbSet<MegaDeskTeamDeseret.Models.Quote> Quote { get; set; }
    }
}
