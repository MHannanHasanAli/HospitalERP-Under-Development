using HospitalERP.Services;
using HospitalERP.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HospitalERP.Web.Controllers
{
    public class RoomController : Controller
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public RoomController(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public IActionResult Index()
        {
            _contextAccessor.HttpContext.Session.SetString("nav-bar", "rooms");
            RoomListingViewModel model = new RoomListingViewModel();
            model.rooms = RoomServices.Instance.GetRooms();
            return View(model);
        }

        [HttpGet]
        public IActionResult Action(int id = 0, int view = 0)
        {
            RoomActionViewModel model = new RoomActionViewModel();

            if (id != 0)
            {
                var room = RoomServices.Instance.GetRoomById(id);
                model = model.GetViewModel(room);

                if (view != 0)
                {
                    model.View = -1;
                }
            }

            return View("Action", model);
        }


        [HttpPost]
        public IActionResult Action(RoomActionViewModel model)
        {
            if (model.Id != 0)
            {
                RoomServices.Instance.UpdateRoom(
                    RoomServices.Instance.GetEntity(model));
            }
            else
            {
                RoomServices.Instance.CreateRoom(
                    RoomServices.Instance.GetEntity(model));
            }


            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Delete(int id = 0)
        {
            if (id != 0)
            {
                RoomServices.Instance.DeleteRoom(id);
            }

            return RedirectToAction("Index");
        }
    }
}
