namespace FuelAppAPI.models
{
    public class MongoDBSettings
    {
        public string ConnectionURI { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string FuelStationCollectionName { get; set; } = null!;
    }
}
