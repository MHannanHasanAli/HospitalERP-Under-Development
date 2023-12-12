using HospitalERP.Entities;

namespace HospitalERP.ViewModels
{
    public class PatientViewModel
    {

    }

    public class PatientListingViewModel
    {

        public PatientListingViewModel()
        {
            Patients = new List<User>();
        }

        public List<User> Patients { get; set; }
    }

    public class PatientActionViewModel()
    {
        public string PatientId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string CNIC { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string BloodGroup { get; set; }
        public List<string> Claims { get; set; }
        public IList<string> Roles { get; set; }

        public User GetViewModel(User user)
        {
            return new User
            {
                Id = user.Id,
                Name = user.Name,
                Age = user.Age,
                CNIC = user.CNIC,
                Phone = user.Phone,
                Address = user.Address,
                Status = user.Status,
                DateOfBirth = user.DateOfBirth,
                BloodGroup = user.BloodGroup
            };
        }
    }
}

