using MongoDB.Bson.Serialization.Attributes;

namespace Hospital.Patient.Entities
{
    public class PatientChild
    {

        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string PatientChildId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string ParentNameSurname { get; set; }
    }
}
