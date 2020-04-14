using Microsoft.AspNetCore.Identity;

namespace Identity.Entities
{
    public partial class ApplicationUserRole : IdentityUserRole<int>
    {
        public int Id { get; set; }

        /*
        public int RoleId { get; set; }
        public int UserId { get; set; }
        */

        public virtual ApplicationRole Role { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
