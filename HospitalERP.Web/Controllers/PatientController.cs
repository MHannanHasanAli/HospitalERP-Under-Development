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

        [HttpGet]
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
        public async Task<IActionResult> Action(string Id = "0", int view = 0)
        {
            if (Id == "0")
            {
                var tempmodel = new PatientActionViewModel();
                tempmodel.Id = "0";
                return View(tempmodel);
            }

            var user = await userManager.FindByIdAsync(Id);

            if (user == null)
            {
                return View("NotFound", "Shared");
            }

            var model = new PatientActionViewModel(user);

            if (view == -1)
            {
                model.View = -1;
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Action(PatientActionViewModel model)
        {

            if (model.View == -1) { return RedirectToAction("Index"); }

            if (model.Id == "0")
            {
                var role = await roleManager.FindByNameAsync("Patient");

                if (role != null)
                {
                    model.Roles.Add(role);
                }

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
                var user = await userManager.FindByIdAsync(model.Id);

                if (user == null)
                {
                    return RedirectToAction("NotFound", "Shared");
                }

                user.Name = model.Name;
                user.Age = model.Age;
                user.BloodGroup = model.BloodGroup;
                user.CNIC = model.CNIC;
                user.DateOfBirth = model.DateOfBirth;
                user.Address = model.Address;
                user.Phone = model.Phone;

                var result = await userManager.UpdateAsync(user);

                if (!result.Succeeded)
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }

                    return RedirectToAction("NotFound", "Shared");
                }

                return RedirectToAction("Index");

            }


        }

        [HttpGet]
        public async Task<IActionResult> Delete(string Id)
        {
            var user = await userManager.FindByIdAsync(Id);

            if (user == null)
            {
                return View("NotFound", "Shared");
            }

            var result = await userManager.DeleteAsync(user);

            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }

            }
            return RedirectToAction("Index");

        }
    }
}
