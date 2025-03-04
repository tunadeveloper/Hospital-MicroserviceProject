namespace Hospital.Patient.Dtos.PatientChildDtos
{
    public class CreatePatientChildDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string ParentNameSurname { get; set; }
    }
}
