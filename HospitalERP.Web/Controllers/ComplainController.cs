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
    }
}
