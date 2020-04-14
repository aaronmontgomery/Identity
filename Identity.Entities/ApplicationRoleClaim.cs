using Microsoft.AspNetCore.Identity;

namespace Identity.Entities
{
    public partial class ApplicationRoleClaim : IdentityRoleClaim<int>
    {
        /*
        public int Id { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        public int RoleId { get; set; }
        */

        public virtual ApplicationRole Role { get; set; }
    }
}
