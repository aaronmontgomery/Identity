using Microsoft.AspNetCore.Identity;

namespace Identity.Entities
{
    public partial class ApplicationUserClaim : IdentityUserClaim<int>
    {
        /*
        public int Id { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        public int UserId { get; set; }
        */

        public virtual ApplicationUser User { get; set; }
    }
}
