using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace FuelAppAPI.models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? email { get; set; }
        public string? mobile { get; set; } 
        public string? password { get; set; }
        public string? type { get; set; }
    }
}
