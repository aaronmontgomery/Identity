using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Identity.Entities
{
    public partial class ApplicationUser : IdentityUser<int>
    {
        public ApplicationUser()
        {
            ApplicationUserClaim = new HashSet<ApplicationUserClaim>();
            ApplicationUserLogin = new HashSet<ApplicationUserLogin>();
            ApplicationUserRole = new HashSet<ApplicationUserRole>();
            ApplicationUserToken = new HashSet<ApplicationUserToken>();
        }

        /*
        public int Id { get; set; }
        public int AccessFailedCount { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool LockoutEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public string NormalizedEmail { get; set; }
        public string NormalizedUserName { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public string SecurityStamp { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public string UserName { get; set; }
        */

        public virtual ICollection<ApplicationUserClaim> ApplicationUserClaim { get; set; }
        public virtual ICollection<ApplicationUserLogin> ApplicationUserLogin { get; set; }
        public virtual ICollection<ApplicationUserRole> ApplicationUserRole { get; set; }
        public virtual ICollection<ApplicationUserToken> ApplicationUserToken { get; set; }
    }
}
