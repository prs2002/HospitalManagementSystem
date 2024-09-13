using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Backend.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("name")]
        public required string Name { get; set; }

        [BsonElement("email")]
        public required string Email { get; set; }

        [BsonElement("passwordHash")]
        public required string PasswordHash { get; set; }

        [BsonElement("profile")]
        public required Profile Profile { get; set; }
    }

    public class Profile
    {
        [BsonElement("address")]
        public required string Address { get; set; }

        [BsonElement("phone")]
        public required string Phone { get; set; }
    }


}
