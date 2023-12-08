using Microsoft.AspNetCore.Mvc;

namespace HospitalERP.Web.Controllers
{
    public class SharedController : Controller
    {
        [HttpPost]
        public IActionResult StoreNavigationClasses(string navigationClasses)
        {
            HttpContext.Session.SetString("bar-situation", navigationClasses);
            return Ok();
        }

        [HttpGet]
        public IActionResult NotFound()
        {
            return View();
        }
    }
}
