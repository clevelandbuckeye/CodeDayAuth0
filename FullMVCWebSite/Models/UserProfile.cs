using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullMVCWebSite.Models
{
    public class UserProfile
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //public ICollection<string> Favorites { get; set; }
    }

    //    public class UserProfileContext : DbContext
    //    {
    //        public UserProfileContext()
    //        {

    //        }
    //        DbSet<UserProfile> UserProfiles { get; set; }
    //    }
}
