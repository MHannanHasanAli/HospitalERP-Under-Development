using Microsoft.AspNetCore.Mvc;

namespace HospitalERP.Web.Controllers
{
    public class DoctorController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
