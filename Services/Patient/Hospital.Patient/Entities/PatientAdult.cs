using MongoDB.Bson.Serialization.Attributes;

namespace Hospital.Patient.Entities
{
    public class PatientAdult
    {

        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string PatientUserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string Gender  { get; set; }
    }
}
