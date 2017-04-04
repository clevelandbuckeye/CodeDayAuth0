using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CodeAPIWithEntity;

namespace CodeAPIWithEntity.Models
{
    public class CodeAPIWithEntityContext : DbContext
    {
        public CodeAPIWithEntityContext (DbContextOptions<CodeAPIWithEntityContext> options)
            : base(options)
        {
        }

        public DbSet<CodeAPIWithEntity.UserProfile> UserProfile { get; set; }
    }
}
