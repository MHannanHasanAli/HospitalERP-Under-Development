using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalERP.Entities
{
    public class Appointment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Description { get; set; }
        [NotMapped]
        public AppUser Doctor { get; set; }
        public AppUser Patient { get; set; }
    }
}
