using System.ComponentModel.DataAnnotations;

namespace HospitalERP.Entities
{
    public class Complain
    {
        [Key]
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now.Date;
    }
}
