using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Identity.Web.Controllers
{
    [AutoValidateAntiforgeryToken]
    [Authorize(Roles ="Administrators")]
    public class RoleController : Controller
    {
        private readonly RoleManager<Entities.ApplicationRole> _roleManager;

        public RoleController(RoleManager<Entities.ApplicationRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpPost]
        public async Task<ActionResult> Create(string rolename)
        {
            Entities.ApplicationRole role = new Entities.ApplicationRole()
            {
                Name = rolename
            };

            await _roleManager.CreateAsync(role);

            return RedirectToAction("cp", "account");
        }

        [HttpPost]
        public async Task<ActionResult> Delete(string rolename)
        {
            Entities.ApplicationRole role = await _roleManager.FindByNameAsync(rolename);
            await _roleManager.DeleteAsync(role);

            return RedirectToAction("cp", "account");
        }
    }
}
