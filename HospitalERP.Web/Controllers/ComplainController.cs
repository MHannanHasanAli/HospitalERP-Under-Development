using HospitalERP.Entities;
using HospitalERP.Services;
using HospitalERP.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HospitalERP.Web.Controllers
{
    public class ComplainController : Controller
    {
        private readonly UserManager<User> userManager;

        public ComplainController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var currentUser = await userManager.GetUserAsync(User);

            var model = new ComplainListingViewModel();

            var complains = ComplainServices.Instance.GetComplains();

            foreach (var item in complains)
            {
                var user = await userManager.FindByIdAsync(item.UserId);

                if (user == null) { continue; }

                var role = await userManager.GetRolesAsync(user);

                var data = new ComplainActionViewModel()
                {
                    Id = item.Id.ToString(),
                    Subject = item.Subject,
                    Description = item.Description,
                    Name = user.Name,
                    Email = user.Email,
                    Role = role?.FirstOrDefault()
                };

                model.Complains.Add(data);
            }
            return View(model);
        }

        public async Task<IActionResult> Action(int Id)
        {
            if (Id == 0) { return View("NotFound", "Shared"); }

            var complain = ComplainServices.Instance.GetComplainById(Id);

            if (complain == null) { return View("NotFound", "Shared"); }

            var model = new ComplainActionViewModel(complain);

            var user = await userManager.FindByIdAsync(model.UserId);

            if (user == null) { return View("NotFound", "Shared"); }

            var role = await userManager.GetRolesAsync(user);
            var rolename = role?.FirstOrDefault();

            model.Name = user.Name;
            model.Email = user.Email;
            model.Role = rolename;


            return View(model);
        }
    }
}
