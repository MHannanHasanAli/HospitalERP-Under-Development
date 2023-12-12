using HospitalERP.Entities;
using HospitalERP.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HospitalERP.Web.Controllers
{
    public class PatientController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public PatientController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            PatientListingViewModel model = new PatientListingViewModel();

            foreach (var user in userManager.Users)
            {
                if (await userManager.IsInRoleAsync(user, "Patient"))
                {
                    model.Patients.Add(user);
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Action(string Id = "0")
        {
            if (Id == "0")
            {
                return View();
            }

            var user = await userManager.FindByIdAsync(Id);

            if (user == null)
            {
                return View("NotFound", "Shared");
            }

            var UserClaims = await userManager.GetClaimsAsync(user);
            var UserRoles = await userManager.GetRolesAsync(user);

            var model = new PatientActionViewModel();

            model.GetViewModel(user);
            model.Roles = UserRoles;
            model.Claims = UserClaims.Select(x => x.Value).ToList();


            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Action(RegisterViewModel model)
        {
            if (model.Id == "0")
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var patient = new User
                {
                    Email = model.Email,
                    UserName = model.Email,
                    Name = model.Name,
                    Age = model.Age,
                    BloodGroup = model.BloodGroup,
                    CNIC = model.CNIC,
                    DateOfBirth = model.DateOfBirth,
                    Address = model.Address,
                    Phone = model.Phone
                };

                var result = await userManager.CreateAsync(patient, model.Password);

                if (!result.Succeeded)
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                    return View(model);
                }

                await userManager.AddToRoleAsync(patient, "Patient");
                return RedirectToAction("Index");
            }
            else
            {

            }

            return View(model);
        }

        [HttpGet]
        public IActionResult EditPatient(string id = "0")
        {
            return View();
        }
    }
}
