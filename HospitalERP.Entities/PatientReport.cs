namespace HospitalERP.Entities
{
    public class PatientReport
    {
        public int Id { get; set; }
        public string Diagnose { get; set; }
        public AppUser Doctor { get; set; }
        public AppUser Patient { get; set; }
        public ICollection<PrescribedMedicine> PrescribedMedicines { get; set; }
    }
}
