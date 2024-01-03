using HospitalERP.Entities;
using Microsoft.AspNetCore.Identity;

namespace HospitalERP.ViewModels
{
    public class PharmacistViewModel
    {
    }

    public class PharmacistListingViewModel()
    {
        public List<User> Pharmacists { get; set; } = new List<User>();
    }

    public class PharmacistActionViewModel()
    {
        public PharmacistActionViewModel(User user) : this()
        {
            Id = user.Id;
            Name = user.Name;
            Age = user.Age;
            CNIC = user.CNIC;
            Phone = user.Phone;
            Address = user.Address;
            DateOfBirth = user.DateOfBirth;
            Salary = user.Salary;
            Position = user.Position;
            Education = user.Education;
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
        public DateOnly DateOfBirth { get; set; }
        public string Salary { get; set; }
        public string Education { get; set; }
        public string Position { get; set; }
        public List<IdentityRole> Roles { get; set; } = new List<IdentityRole>();
        public int View { get; set; }
    }
}
