namespace HospitalERP.Entities
{
    public class PrescribedMedicine
    {
        public int Id { get; set; }
        public Medicine Medicine { get; set; }
        public PatientReport PatientReport { get; set; }
    }
}
