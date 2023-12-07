using HospitalERP.Entities;
using HospitalERP.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HospitalERP.Web.Controllers
{
    public class PatientController : Controller
    {
        private readonly UserManager<User> userManager;

        public PatientController(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Action(string Id = "0")
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Action(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var patient = new User
                {
                    Email = model.Email,
                    UserName = model.Email

                };

                var result = await userManager.CreateAsync(patient, model.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Hospital");
                }

                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }

            return View(model);
        }
    }
}
