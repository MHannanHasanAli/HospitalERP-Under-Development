using HospitalERP.Entities;
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

    public class EditRoleViewModel
    {
        public EditRoleViewModel()
        {
            Users = new List<User>();
        }
        public string Id { get; set; }
        [Required]
        public string RoleName { get; set; }

        public List<User> Users { get; set; }
    }
}
