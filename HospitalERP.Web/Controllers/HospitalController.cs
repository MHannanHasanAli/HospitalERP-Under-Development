using HospitalERP.Services;
using HospitalERP.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HospitalERP.Web.Controllers
{
    public class HospitalController : Controller
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public HospitalController(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public IActionResult Index()
        {
            _contextAccessor.HttpContext.Session.SetString("nav-bar", "hospital");
            HospitalListingViewModel model = new HospitalListingViewModel();
            model.Hospitals = HospitalServices.Instance.GetHospitals();
            return View(model);
        }

        [HttpGet]
        public IActionResult Action(int id = 0, int view = 0)
        {
            HospitalActionViewModel model = new HospitalActionViewModel();

            if (id != 0)
            {
                var hospital = HospitalServices.Instance.GetHospitalById(id);
                model = model.GetViewModel(hospital);

                if (view != 0)
                {
                    model.View = -1;
                }
            }

            return View("Action", model);
        }


        [HttpPost]
        public IActionResult Action(HospitalActionViewModel model)
        {
            if (model.Id != 0)
            {
                HospitalServices.Instance.UpdateHospital(
                    HospitalServices.Instance.GetEntity(model));
            }
            else
            {
                HospitalServices.Instance.CreateHospital(
                    HospitalServices.Instance.GetEntity(model));
            }


            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Delete(int id = 0)
        {
            if (id != 0)
            {
                HospitalServices.Instance.DeleteHospital(id);
            }

            return RedirectToAction("Index");
        }
    }
}
