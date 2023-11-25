using HospitalERP.Database;
using HospitalERP.Entities;
using HospitalERP.ViewModels;

namespace HospitalERP.Services
{
    public class HospitalServices
    {
        #region Singleton
        public static HospitalServices Instance
        {
            get
            {
                if (instance == null) instance = new HospitalServices();
                return instance;
            }
        }
        private static HospitalServices instance { get; set; }
        private HospitalServices()
        {
        }
        #endregion

        #region Services
        public List<Hospital> GetHospitals(string SearchTerm = "")
        {
            using (var context = new AppDbContext())
            {
                if (SearchTerm != "")
                {
                    return context.Hospitals.Where(p => p.Name != null && p.Name.ToLower()
                                            .Contains(SearchTerm.ToLower()))
                                            .OrderBy(x => x.Name)
                                            .ToList();
                }
                else
                {
                    return context.Hospitals.OrderBy(x => x.Name).ToList();
                }
            }
        }
        public Hospital GetHospitalById(int id)
        {
            using (var context = new AppDbContext())
            {
                return context.Hospitals.Find(id);
            }
        }
        public void CreateHospital(Hospital HospitalInfo)
        {
            using (var context = new AppDbContext())
            {
                context.Hospitals.Add(HospitalInfo);
                context.SaveChanges();
            }
        }
        public void UpdateHospital(Hospital HospitalInfo)
        {
            using (var context = new AppDbContext())
            {
                context.Hospitals.Update(HospitalInfo);
                context.SaveChanges();
            }
        }
        public void DeleteHospital(int ID)
        {
            using (var context = new AppDbContext())
            {
                var hospital = context.Hospitals.Find(ID);
                context.Hospitals.Remove(hospital);
                context.SaveChanges();
            }
        }


        public Hospital GetEntity(HospitalActionViewModel model)
        {
            return new Hospital
            {
                Id = model.Id,
                Name = model.Name,
                Type = model.Type,
                City = model.City,
                Pincode = model.Pincode,
                Country = model.Country
            };
        }
        #endregion
    }
}
