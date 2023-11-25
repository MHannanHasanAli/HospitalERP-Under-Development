namespace HospitalERP.Entities
{
    public class Lab
    {
        public int Id { get; set; }
        public string LabNumber { get; set; }
        public AppUser Patient { get; set; }
        public string TestType { get; set; }
        public string TestCode { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public int BloodPressure { get; set; }
        public int Temparature { get; set; }
        public string TestResult { get; set; }
    }
}
