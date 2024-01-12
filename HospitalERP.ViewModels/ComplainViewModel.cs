using HospitalERP.Entities;

namespace HospitalERP.ViewModels
{
    public class ComplainViewModel
    {
    }

    public class ComplainListingViewModel()
    {
        public List<ComplainActionViewModel> Complains = new List<ComplainActionViewModel>();

    }

    public class ComplainActionViewModel()
    {
        public ComplainActionViewModel(Complain complain) : this()
        {
            Id = complain.Id.ToString();
            Subject = complain.Subject;
            Description = complain.Description;
            UserId = complain.UserId;
            Date = complain.CreatedDate;
        }
        public string Id { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public DateTime Date { get; set; }
    }
}
