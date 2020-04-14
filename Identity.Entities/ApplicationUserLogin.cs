using Microsoft.AspNetCore.Identity;

namespace Identity.Entities
{
    public partial class ApplicationUserLogin : IdentityUserLogin<int>
    {
        public int Id { get; set; }

        /*
        public string LoginProvider { get; set; }
        public string ProviderDisplayName { get; set; }
        public string ProviderKey { get; set; }
        public int UserId { get; set; }
        */

        public virtual ApplicationUser User { get; set; }
    }
}
