using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeAPIWithEntity
{
    public class UserProfile
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string StringId { get; set; }
        public string Description { get; set; }
        public string ProfilePicture { get; set; }
        public string Description2 { get; set; }
    }
}
