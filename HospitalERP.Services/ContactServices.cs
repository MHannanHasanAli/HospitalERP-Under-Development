using HospitalERP.Database;
using HospitalERP.Entities;
using HospitalERP.ViewModels;

namespace HospitalERP.Services
{
    public class ContactServices
    {
        #region Singleton
        public static ContactServices Instance
        {
            get
            {
                if (instance == null) instance = new ContactServices();
                return instance;
            }
        }
        private static ContactServices instance { get; set; }
        private ContactServices()
        {
        }
        #endregion

        #region Services
        public List<Contact> GetContacts(string SearchTerm = "")
        {
            using (var context = new AppDbContext())
            {
                if (SearchTerm != "")
                {
                    return context.Contacts.Where(p => p.Email != null && p.Email.ToLower()
                                            .Contains(SearchTerm.ToLower()))
                                            .OrderBy(x => x.Email)
                                            .ToList();
                }
                else
                {
                    return context.Contacts.OrderBy(x => x.Email).ToList();
                }
            }
        }
        public Contact GetContactById(int id)
        {
            using (var context = new AppDbContext())
            {
                return context.Contacts.Find(id);
            }
        }
        public void CreateContact(Contact ContactInfo)
        {
            using (var context = new AppDbContext())
            {
                context.Contacts.Add(ContactInfo);
                context.SaveChanges();
            }
        }
        public void UpdateContact(Contact ContactInfo)
        {
            using (var context = new AppDbContext())
            {
                context.Contacts.Update(ContactInfo);
                context.SaveChanges();
            }
        }
        public void DeleteContact(int ID)
        {
            using (var context = new AppDbContext())
            {
                var hospital = context.Contacts.Find(ID);
                context.Contacts.Remove(hospital);
                context.SaveChanges();
            }
        }


        public Contact GetEntity(ContactActionViewModel model)
        {
            return new Contact
            {
                Id = model.Id,
                Email = model.Email,
                Phone = model.Phone,
                HospitalId = model.HospitalId
            };
        }
        #endregion
    }
}
