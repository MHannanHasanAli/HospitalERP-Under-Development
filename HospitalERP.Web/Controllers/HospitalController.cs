using HospitalERP.Services;
using HospitalERP.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HospitalERP.Web.Controllers
{
    public class HospitalController : Controller
    {
        public IActionResult Index()
        {
            HospitalListingViewModel model = new HospitalListingViewModel();
            model.Hospitals = HospitalServices.Instance.GetHospitals();
            return View(model);
        }

        [HttpGet]
        public ActionResult Action(int ID = 0)
        {
            HospitalActionViewModel model = new HospitalActionViewModel();

            if (ID != 0)
            {
                var hospital = HospitalServices.Instance.GetHospitalById(ID);
                model.GetViewModel(hospital);
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


            return Json(new { success = true });
        }


        [HttpPost]
        public IActionResult Delete(HospitalActionViewModel model)
        {
            if (model.Id != 0)
            {

                HospitalServices.Instance.DeleteHospital(model.Id);
            }

            return Json(new { success = true });
        }
    }
}
