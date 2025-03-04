namespace Hospital.Patient.Dtos.PatientAdultDtos
{
    public class GetByIdPatientAdultDto
    {
        public string PatientUserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string Gender { get; set; }
    }
}
