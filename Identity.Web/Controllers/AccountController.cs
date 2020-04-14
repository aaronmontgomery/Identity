using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Identity.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<Entities.ApplicationUser> _userManager;
        private readonly RoleManager<Entities.ApplicationRole> _roleManager;
        private readonly SignInManager<Entities.ApplicationUser> _signInManager;

        public AccountController(UserManager<Entities.ApplicationUser> userManager,
            RoleManager<Entities.ApplicationRole> roleManager,
            SignInManager<Entities.ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        [Authorize(Roles ="Administrators")]
        public IActionResult Cp()
        {
            IQueryable<Entities.ApplicationUser> users = _userManager.Users;
            IQueryable<Entities.ApplicationRole> roles = _roleManager.Roles;

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> SignIn(string username, string password)
        {
            Entities.ApplicationUser user = await _userManager.FindByNameAsync(username);
            if (await _userManager.CheckPasswordAsync(user, password))
            {
                await _signInManager.SignInAsync(user, false);
            }

            return RedirectToAction("index", "home");
        }

        [HttpPost]
        public async Task<ActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("index", "home");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
    }
}
