using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ChatSignalR.Models
{
    public class Chat
    {
        public Chat(long id, string user, string message)
        {
            Id = id;
            User = user;
            Message = message;
        }

        [BsonId]
        public ObjectId InternalId { get; set; }
        public long Id { get; set; }
        public string User { get; set; }
        public string Message { get; set; }
    }
}
