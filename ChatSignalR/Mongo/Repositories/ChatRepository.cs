using ChatSignalR.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ChatSignalR.Mongo.Repositories
{
    public class ChatRepository : IChatRepository
    {
        private readonly IChatContext _context;

        public ChatRepository(IChatContext context)
        {
            _context = context;
        }

        public async Task Create(Chat chat)
        {
            await _context.Chats.InsertOneAsync(chat);
        }

        public async Task<IEnumerable<Chat>> GetAllChats()
        {
            return await _context
                           .Chats
                           .Find(_ => true)
                           .ToListAsync();
        }

        public async Task<Chat> GetChat(long id)
        {
            FilterDefinition<Chat> filter = Builders<Chat>.Filter.Eq(m => m.Id, id);
            return await _context
                    .Chats
                    .Find(filter)
                    .FirstOrDefaultAsync();
        }

        public async Task<Chat> GetLastMessage()
        {
            var id = await _context.Chats.CountDocumentsAsync(new BsonDocument());

            FilterDefinition<Chat> filter = Builders<Chat>.Filter.Eq(m => m.Id, id);
            return await _context
                    .Chats
                    .Find(filter)
                    .FirstOrDefaultAsync();
        }
        public async Task<long> GetNextId()
        {
            return await _context.Chats.CountDocumentsAsync(new BsonDocument()) + 1; 
        }
    }
}
