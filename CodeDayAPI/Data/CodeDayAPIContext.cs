using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CodeDayAPI;

namespace CodeDayAPI.Models
{
    public class CodeDayAPIContext : DbContext
    {
        public CodeDayAPIContext (DbContextOptions<CodeDayAPIContext> options)
            : base(options)
        {
        }

        public DbSet<CodeDayAPI.UserProfile> UserProfile { get; set; }
    }
}
