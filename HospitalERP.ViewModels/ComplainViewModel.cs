namespace HospitalERP.ViewModels
{
    public class ComplainViewModel
    {
    }

    public class ComplainListingViewModel()
    {
        public List<ComplainActionViewModel> Complains { get; set; }
    }

    public class ComplainActionViewModel()
    {
        public string Id { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
