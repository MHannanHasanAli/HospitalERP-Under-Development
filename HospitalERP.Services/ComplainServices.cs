using HospitalERP.Database;
using HospitalERP.Entities;

namespace HospitalERP.Services
{
    public class ComplainServices
    {
        #region Singleton
        public static ComplainServices instance { get; set; }
        public static ComplainServices Instance
        {
            get
            {
                if (instance == null) instance = new ComplainServices();
                return instance;
            }
        }
        public ComplainServices() { }
        #endregion

        #region Services

        public List<Complain> GetComplains()
        {
            using (var context = new AppDbContext())
            {
                return context.Complains.ToList();
            }
        }

        public Complain GetComplainById(int id)
        {
            using (var context = new AppDbContext())
            {
                return context.Complains.Find(id);
            }
        }

        public void CreateComplain(Complain complain)
        {
            using (var context = new AppDbContext())
            {
                context.Complains.Add(complain);
                context.SaveChanges();
            }
        }

        public void UpdateComplain(Complain complain)
        {
            using (var context = new AppDbContext())
            {
                context.Complains.Update(complain);
                context.SaveChanges();
            }
        }

        public void DeleteComplain(int id)
        {
            using (var context = new AppDbContext())
            {
                context.Complains.Remove(GetComplainById(id));
                context.SaveChanges();
            }
        }
        #endregion
    }
}
