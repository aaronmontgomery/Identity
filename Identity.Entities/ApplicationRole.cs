using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Identity.Entities
{
    public partial class ApplicationRole : IdentityRole<int>
    {
        public ApplicationRole()
        {
            ApplicationRoleClaim = new HashSet<ApplicationRoleClaim>();
            ApplicationUserRole = new HashSet<ApplicationUserRole>();
        }

        /*
        public int Id { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        */

        public virtual ICollection<ApplicationRoleClaim> ApplicationRoleClaim { get; set; }
        public virtual ICollection<ApplicationUserRole> ApplicationUserRole { get; set; }
    }
}
