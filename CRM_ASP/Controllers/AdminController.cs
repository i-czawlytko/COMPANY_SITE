using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using CRM_ASP.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace CRM_ASP.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private UserManager<IdentityUser> userManager;
        public AdminController(UserManager<IdentityUser> usrMrg)
        {
            userManager = usrMrg;
        }
        public IActionResult Index() => View(userManager.Users);

        public ViewResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(UserCreateModel model)
        {
            if(ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = model.Name,
                    Email = model.Email
                };
                IdentityResult result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach(IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }

    }
}