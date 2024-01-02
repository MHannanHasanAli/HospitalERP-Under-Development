using HospitalERP.Entities;
using Microsoft.AspNetCore.Identity;

namespace HospitalERP.ViewModels
{

    public class PatientListingViewModel()
    {
        public List<User> Patients { get; set; } = new List<User>();
    }

    public class PatientActionViewModel()
    {
        public PatientActionViewModel(User user) : this()
        {
            Id = user.Id;
            Name = user.Name;
            Age = user.Age;
            CNIC = user.CNIC;
            Phone = user.Phone;
            Address = user.Address;
            //Status = user.Status;
            DateOfBirth = user.DateOfBirth;
            BloodGroup = user.BloodGroup;
            View = 0;
            //Claims = new List<string>();
            Roles = new List<IdentityRole>();
        }
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string CNIC { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        //public string Status { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string BloodGroup { get; set; }
        //public List<string> Claims { get; set; }
        public IList<IdentityRole> Roles { get; set; } = new List<IdentityRole>();
        public int View { get; set; } = 0;
    }
}
