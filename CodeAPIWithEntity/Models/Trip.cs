using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeAPIWithEntity.Models
{
    public class Trip
    {
        public long Id { get; set; }
        public ICollection<Stop> Stops { get; set; }
        public string Name { get; set; }
    }
    public class Stop
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
    public class WorldContext : DbContext
    {
        public WorldContext()
        {

        }

        public DbSet<Trip> Trips { get; set; }
        public DbSet<Stop> Stops { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInternalServiceProvider(null);
        }
    }
}
