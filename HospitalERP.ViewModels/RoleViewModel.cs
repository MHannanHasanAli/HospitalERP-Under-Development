using System.ComponentModel.DataAnnotations;

namespace HospitalERP.ViewModels
{
    public class RoleViewModel
    {
    }

    public class CreateRoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
