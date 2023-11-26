using HospitalERP.Entities;

namespace HospitalERP.ViewModels
{
    public class ContactViewModel
    {
    }

    public class ContactListingViewModel
    {
        List<Contact> contacts = new List<Contact>();
    }

    public class ContactActionViewModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int HospitalId { get; set; }

        public ContactActionViewModel GetViewModel(Contact contact)
        {
            return new ContactActionViewModel
            {
                Id = contact.Id,
                Email = contact.Email,
                Phone = contact.Phone,
                HospitalId = contact.HospitalId
            };
        }

        public int View { get; set; }
    }
}
