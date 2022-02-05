using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace _200864D_AS_SITCONNECT.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        [Column(TypeName = "nvarChar(100)")]
        public string FirstName { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarChar(100)")]
        public string LastName { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarChar(100)")]
        public string CreditCard { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarChar(100)")]
        public string BirthDate { get; set; }
    }
}
