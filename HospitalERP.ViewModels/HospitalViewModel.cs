using HospitalERP.Entities;

namespace HospitalERP.ViewModels
{
    public class HospitalViewModel
    {

    }
    public class HospitalListingViewModel
    {
        public List<Hospital> Hospitals { get; set; }
    }

    public class HospitalActionViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string City { get; set; }
        public string Pincode { get; set; }
        public string Country { get; set; }
        public HospitalActionViewModel GetViewModel(Hospital hospital)
        {
            return new HospitalActionViewModel
            {
                Id = hospital.Id,
                Name = hospital.Name,
                Type = hospital.Type,
                City = hospital.City,
                Pincode = hospital.Pincode,
                Country = hospital.Country
            };
        }
    }
}
