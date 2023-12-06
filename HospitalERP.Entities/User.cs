using Microsoft.AspNetCore.Identity;

namespace HospitalERP.Entities
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string CNIC { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }


        public DateTime RegistrationDate { get; set; } = DateTime.Now;
        public DateTime DateOfBirth { get; set; }
        public DateTime AdmittedDate { get; set; }
        public DateTime DischargeDate { get; set; }


        public string BloodGroup { get; set; }
        public string Salary { get; set; }
        public string Education { get; set; }
        public string Position { get; set; }


        public int HospitalId { get; set; }
        public int RoomId { get; set; }
        public int DepartmentId { get; set; }

    }
}
