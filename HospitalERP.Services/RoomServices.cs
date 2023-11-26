using HospitalERP.Database;
using HospitalERP.Entities;
using HospitalERP.ViewModels;

namespace HospitalERP.Services
{
    public class RoomServices
    {
        #region Singleton
        public static RoomServices Instance
        {
            get
            {
                if (instance == null) instance = new RoomServices();
                return instance;
            }
        }
        private static RoomServices instance { get; set; }
        private RoomServices()
        {
        }
        #endregion

        #region Services
        public List<Room> GetRooms(string SearchTerm = "")
        {
            using (var context = new AppDbContext())
            {
                if (SearchTerm != "")
                {
                    return context.Rooms.Where(p => p.RoomNumber != null && p.RoomNumber.ToLower()
                                            .Contains(SearchTerm.ToLower()))
                                            .OrderBy(x => x.RoomNumber)
                                            .ToList();
                }
                else
                {
                    return context.Rooms.OrderBy(x => x.RoomNumber).ToList();
                }
            }
        }
        public Room GetRoomById(int id)
        {
            using (var context = new AppDbContext())
            {
                return context.Rooms.Find(id);
            }
        }
        public void CreateRoom(Room RoomInfo)
        {
            using (var context = new AppDbContext())
            {
                context.Rooms.Add(RoomInfo);
                context.SaveChanges();
            }
        }
        public void UpdateRoom(Room RoomInfo)
        {
            using (var context = new AppDbContext())
            {
                context.Rooms.Update(RoomInfo);
                context.SaveChanges();
            }
        }
        public void DeleteRoom(int ID)
        {
            using (var context = new AppDbContext())
            {
                var hospital = context.Rooms.Find(ID);
                context.Rooms.Remove(hospital);
                context.SaveChanges();
            }
        }


        public Room GetEntity(RoomActionViewModel model)
        {
            return new Room
            {
                Id = model.Id,
                Type = model.Type,
                RoomNumber = model.RoomNumber,
                Status = model.Status,
                HospitalId = model.HospitalId
            };
        }
        #endregion
    }
}
