using HospitalERP.Entities;
using HospitalERP.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HospitalERP.Web.Controllers
{
    public class SecurityController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public SecurityController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = new SecurityListingViewModel();

            foreach (var user in userManager.Users)
            {
                if (await userManager.IsInRoleAsync(user, "Security"))
                {
                    model.Securitys.Add(user);
                }
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Action(string Id = "0", int view = 0)
        {
            if (Id == "0")
            {
                var Createmodel = new SecurityActionViewModel();
                Createmodel.Id = "0";
                return View(Createmodel);
            }

            var user = await userManager.FindByIdAsync(Id);

            if (user == null)
            {
                return RedirectToAction("NotFound", "Shared");
            }

            var model = new SecurityActionViewModel(user);

            if (view == -1) { model.View = -1; }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Action(SecurityActionViewModel model)
        {
            if (model.View == -1) { return RedirectToAction("Index"); }

            if (model.Id == "0")
            {
                var role = await roleManager.FindByNameAsync("Security");

                if (role != null) { model.Roles.Add(role); }

                if (!ModelState.IsValid) { return View(model); }


                var Security = new User
                {
                    Email = model.Email,
                    UserName = model.Email,
                    Name = model.Name,
                    DateOfBirth = model.DateOfBirth,
                    Age = model.Age,
                    Address = model.Address,
                    Phone = model.Phone,
                    Salary = model.Salary,
                    Position = model.Position,
                    CNIC = model.CNIC,
                };

                var result = await userManager.CreateAsync(Security, model.Password);

                if (!result.Succeeded)
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }

                    return View(model);
                }

                await userManager.AddToRoleAsync(Security, role.Name);
            }
            else
            {
                var user = await userManager.FindByIdAsync(model.Id);

                if (user == null) { return RedirectToAction("NotFound", "Shared"); }

                user.Name = model.Name;
                user.CNIC = model.CNIC;
                user.DateOfBirth = model.DateOfBirth;
                user.Age = model.Age;
                user.Address = model.Address;
                user.Phone = model.Phone;
                user.Salary = model.Salary;
                user.Position = model.Position;

                var result = await userManager.UpdateAsync(user);

                if (!result.Succeeded)
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }

                    return View(model);
                }

            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await userManager.FindByIdAsync(id);

            if (user == null) { return View("NotFound", "Shared"); }

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
