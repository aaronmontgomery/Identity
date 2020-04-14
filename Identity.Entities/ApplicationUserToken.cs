using Microsoft.AspNetCore.Identity;

namespace Identity.Entities
{
    public partial class ApplicationUserToken : IdentityUserToken<int>
    {
        public int Id { get; set; }

        /*
        public string LoginProvider { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public string Value { get; set; }
        */

        public virtual ApplicationUser User { get; set; }
    }
}
