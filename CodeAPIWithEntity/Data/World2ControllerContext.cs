using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CodeAPIWithEntity.Models
{
    public class World2ControllerContext : DbContext
    {
        public World2ControllerContext (DbContextOptions<World2ControllerContext> options)
            : base(options)
        {
        }

        public DbSet<CodeAPIWithEntity.Models.Stop> Stop { get; set; }
    }
}
