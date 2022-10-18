using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace FuelAppAPI.models
{
    public class FuelStation
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string ?area { get; set; }
        public string ?name { get; set; }
        public int currentQueSize { get; set; }
        public double averageTimeSpent { get; set; }
        public int updateVersionCount { get; set; }

        public List<FuelType> fuelTypes { get; set; } = null;

    }
}
