using HospitalERP.Entities;
using HospitalERP.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HospitalERP.Web.Controllers
{
    public class SupplierController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public SupplierController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = new SupplierListingViewModel();

            foreach (var user in userManager.Users)
            {
                if (await userManager.IsInRoleAsync(user, "Supplier"))
                {
                    model.Suppliers.Add(user);
                }
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Action(string Id = "0", int view = 0)
        {
            if (Id == "0")
            {
                var Createmodel = new SupplierActionViewModel();
                Createmodel.Id = "0";
                return View(Createmodel);
            }

            var user = await userManager.FindByIdAsync(Id);

            if (user == null) { return RedirectToAction("NotFound", "Shared"); }

            var model = new SupplierActionViewModel(user);

            if (view == -1) { model.View = -1; }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Action(SupplierActionViewModel model)
        {
            if (model.View == -1) { return RedirectToAction("index"); }

            if (model.Id == "0")
            {
                var role = await roleManager.FindByNameAsync("Supplier");

                if (role == null) { return RedirectToAction("NotFound", "Shared"); }

                model.Roles.Add(role);

                if (!ModelState.IsValid)
                {
                    return RedirectToAction("NotFound", "Shared");
                }

                var Supplier = new User()
                {
                    Email = model.Email,
                    UserName = model.Email,
                    Name = model.Name,
                    Age = model.Age,
                    CNIC = model.CNIC,
                    Phone = model.Phone,
                    Address = model.Address,
                    DateOfBirth = model.DateOfBirth,
                };

                var result = await userManager.CreateAsync(Supplier, model.Password);

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                    return View(model);
                }

                await userManager.AddToRoleAsync(Supplier, role.Name);

            }
            else
            {
                var user = await userManager.FindByIdAsync(model.Id);

                if (user == null) { return RedirectToAction("NotFound", "Shared"); }

                user.Name = model.Name;
                user.Phone = model.Phone;
                user.Address = model.Address;
                user.CNIC = model.CNIC;
                user.DateOfBirth = model.DateOfBirth;
                user.Age = model.Age;

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
