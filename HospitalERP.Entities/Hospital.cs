using System.ComponentModel.DataAnnotations;

namespace HospitalERP.Entities
{
    public class Hospital
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string City { get; set; }
        public string Pincode { get; set; }
        public string Country { get; set; }
    }
}
