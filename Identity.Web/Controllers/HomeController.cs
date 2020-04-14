using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace Identity.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<Entities.ApplicationUser> _userManager;
        private readonly RoleManager<Entities.ApplicationRole> _roleManager;

        public HomeController(UserManager<Entities.ApplicationUser> userManager,
            RoleManager<Entities.ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            // set up test user
            Entities.ApplicationUser defaultUser = new Entities.ApplicationUser()
            {
                UserName = "default",
                Email = "default@email.com",
                PhoneNumber = "000-000-0000",
            };

            // set up test Administrators role
            Entities.ApplicationRole administratorsRole = new Entities.ApplicationRole()
            {
                Name = "Administrators"
            };

            Entities.ApplicationUser user = await _userManager.FindByNameAsync(defaultUser.UserName);
            Entities.ApplicationRole role = await _roleManager.FindByNameAsync(administratorsRole.Name);

            if (user == null && role == null)
            {
                await _userManager.CreateAsync(defaultUser, "Testpassword#1");
                await _roleManager.CreateAsync(administratorsRole);
                await _userManager.AddToRolesAsync(defaultUser, new string[] { administratorsRole.Name });
            }            

            return View();
        }
    }
}
