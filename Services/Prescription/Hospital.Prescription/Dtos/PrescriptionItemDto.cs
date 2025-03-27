namespace Hospital.Prescription.Dtos
{
    public class PrescriptionItemDto
    {
        public int PrescriptionId { get; set; }
        public string Medicine { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
