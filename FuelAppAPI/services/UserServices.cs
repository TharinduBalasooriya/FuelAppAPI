using FuelAppAPI.models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace FuelAppAPI.services
{
    public class UserServices
    {
        private readonly IMongoCollection<User> _userCollection;

        public UserServices(IOptions<MongoDBSettings> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _userCollection = database.GetCollection<User>(mongoDBSettings.Value.UserCollectionName);
        }

        public async Task<List<User>> GetAsync()
        {
            return await _userCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<User?> LoginAsync(string email , string password) =>
            await _userCollection.Find( (acc => (acc.email == email && acc.password == password))).FirstOrDefaultAsync();

        public async Task<User?> GetAsync(string id) =>
        await _userCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task UpdateAsync(string id,User user)
        {

            await _userCollection.ReplaceOneAsync(x => x.Id == id, user);
        }

        public async Task RemoveAsync(string id) =>
            await _userCollection.DeleteOneAsync(x => x.Id == id);

        public async Task<User?> createAsync(User user)
        {
            var res = _userCollection.Find(x => x.email == user.email).FirstOrDefault();

            if (res is null) {
                await _userCollection.InsertOneAsync(user);
            }
            else {
                user = null;
                await Task.FromResult<string>(null);
               
            }

            return user;
        }
    }
}
