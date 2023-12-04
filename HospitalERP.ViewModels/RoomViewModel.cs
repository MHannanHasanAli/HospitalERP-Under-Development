using HospitalERP.Entities;

namespace HospitalERP.ViewModels
{
    public class RoomViewModel
    {

    }

    public class RoomListingViewModel
    {
        public List<Room> rooms = new List<Room>();
    }

    public class RoomActionViewModel
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; }

        public string Type { get; set; }

        public string Status { get; set; }

        public int HospitalId { get; set; }
        public Hospital Hospital { get; set; }

        public RoomActionViewModel GetViewModel(Room room)
        {
            return new RoomActionViewModel
            {
                Id = room.Id,
                Type = room.Type,
                Status = room.Status,
                RoomNumber = room.RoomNumber,
                HospitalId = room.HospitalId,

            };
        }
        public int View { get; set; }
        public List<Hospital> Hospitals { get; set; }
    }

}
