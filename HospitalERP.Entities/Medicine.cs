namespace HospitalERP.Entities
{
    public class Medicine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
        public decimal Price { get; set; }
        public string Company { get; set; }
        public int Quantity { get; set; }
        public DateTime ProductionDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int SupplierId { get; set; }
    }
}
