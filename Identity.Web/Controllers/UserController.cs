using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Identity.Web.Controllers
{
    [AutoValidateAntiforgeryToken]
    [Authorize(Roles ="Administrators")]
    public class UserController : Controller
    {
        private readonly UserManager<Entities.ApplicationUser> _userManager;

        public UserController(UserManager<Entities.ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<ActionResult> Create(string username, string password, string confirm)
        {
            if (password == confirm)
            {
                Entities.ApplicationUser user = new Entities.ApplicationUser()
                {
                    UserName = username,
                    Email = "test@email.com",
                    PhoneNumber = "999-999-9999",
                };

                await _userManager.CreateAsync(user, password);
            }

            return RedirectToAction("cp", "home");
        }

        [HttpPost]
        public async Task<ActionResult> Delete(string username)
        {
            Entities.ApplicationUser user = await _userManager.FindByNameAsync(username);
            await _userManager.DeleteAsync(user);
            return RedirectToAction("cp", "home");
        }

        [HttpPost]
        public async Task<ActionResult> AddUsersToRoles(string usernames, string rolenames)
        {
            string[] userNames = usernames.Split(", ");
            string[] roleNames = rolenames.Split(", ");
            foreach (string userName in userNames)
            {
                Entities.ApplicationUser user = await _userManager.FindByNameAsync(userName);
                await _userManager.AddToRolesAsync(user, roleNames);
            }

            return RedirectToAction("cp", "home");
        }

        [HttpPost]
        public async Task<ActionResult> RemoveUsersFromRoles(string usernames, string rolenames)
        {
            string[] userNames = usernames.Split(", ");
            string[] roleNames = rolenames.Split(", ");
            foreach (string userName in userNames)
            {
                Entities.ApplicationUser user = await _userManager.FindByNameAsync(userName);
                await _userManager.RemoveFromRolesAsync(user, roleNames);
            }

            return RedirectToAction("cp", "home");
        }
    }
}
