using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Backend.Models
{
    public class Appointment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("patientId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string PatientId { get; set; }

        [BsonElement("providerId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProviderId { get; set; }

        [BsonElement("appointmentDate")]
        public DateTime AppointmentDate { get; set; }

        [BsonElement("status")]
        public string Status { get; set; }

        [BsonElement("notes")]
        [BsonIgnoreIfNull]
        public string Notes { get; set; }
    }


}