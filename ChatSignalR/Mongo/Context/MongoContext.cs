using ChatSignalR.Models;
using ChatSignalR.Mongo.Config;
using MongoDB.Driver;

namespace ChatSignalR.Mongo.Context
{
    public class MongoContext : IChatContext
    {
        private readonly IMongoDatabase _db;

        public MongoContext(MongoDBConfig config)
        {
            var client = new MongoClient(config.ConnectionString);
            _db = client.GetDatabase(config.Database);
        }

        public IMongoCollection<Chat> Chats => _db.GetCollection<Chat>("Chats");

    }
}
