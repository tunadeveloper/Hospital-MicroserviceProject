namespace Hospital.Patient.Settings
{
    public interface IDatabaseSettings
    {
        public string PatientAdultCollectionName { get; set; }
        public string PatientChildCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
