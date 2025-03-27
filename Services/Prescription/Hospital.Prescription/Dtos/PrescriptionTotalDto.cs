namespace Hospital.Prescription.Dtos
{
    public class PrescriptionTotalDto
    {
        public string UserId { get; set; }
        public string DoctorName { get; set; }
        public List<PrescriptionItemDto> PrescriptionItems { get; set; }
        public decimal TotalPrice { get=>PrescriptionItems.Sum(x=>x.Price*x.Quantity);}
    }
}
