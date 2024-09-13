using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Backend.Models
{
    public class Provider
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("userId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string UserId { get; set; }

        [BsonElement("name")]
        public required string Name { get; set; }

        [BsonElement("email")]
        public required string Email { get; set; }

        [BsonElement("specialization")]
        public string Specialization { get; set; }

        [BsonElement("availability")]
        public List<Availability> Availability { get; set; }
    }

    public class Availability
    {
        [BsonElement("day")]
        public string Day { get; set; }

        [BsonElement("startTime")]
        public string StartTime { get; set; }

        [BsonElement("endTime")]
        public string EndTime { get; set; }
    }


}
