using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.DataAccess
{
    public class AppUser : IdentityUser<int>

    {

        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int UserType { get; set; }
        public string NID { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public DateTime Created { get; set; }

        public ICollection<AppUserRole> UserRoles { get; set; }

    }
}
