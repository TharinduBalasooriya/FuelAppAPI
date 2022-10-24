using MongoDB.Driver;
using FuelAppAPI.models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;

namespace FuelAppAPI.services
{
    public class FuelStationService
    {
        private readonly IMongoCollection<FuelStation> _fuelStationCollection;

        public FuelStationService(IOptions<MongoDBSettings> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _fuelStationCollection = database.GetCollection<FuelStation>(mongoDBSettings.Value.FuelStationCollectionName);
        }

        public async Task<List<FuelStation>> GetAsync()
        {
            return await _fuelStationCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<FuelStation?> GetAsync(string id) =>
        await _fuelStationCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task createAsync(FuelStation fuelStation)
        {
            await _fuelStationCollection.InsertOneAsync(fuelStation);
        }

        public async Task UpdateAsync(string id, FuelStation updatedFuelStation)
        {

            await _fuelStationCollection.ReplaceOneAsync(x => x.Id == id, updatedFuelStation);
        }

        public async Task RemoveAsync(string id) =>
            await _fuelStationCollection.DeleteOneAsync(x => x.Id == id);

    }
}
