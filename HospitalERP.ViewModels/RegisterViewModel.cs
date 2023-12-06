using System.ComponentModel.DataAnnotations;

namespace HospitalERP.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password does not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string CNIC { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Address { get; set; }

        public string Status { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }
        public DateTime AdmittedDate { get; set; }
        public DateTime DischargeDate { get; set; }


        public string BloodGroup { get; set; }
        public string Salary { get; set; }
        public string Education { get; set; }
        public string Position { get; set; }


        [Required]
        public int HospitalId { get; set; }
        public int RoomId { get; set; }
        public int DepartmentId { get; set; }
    }
}
