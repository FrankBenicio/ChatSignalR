using ChatSignalR.Models;
using MongoDB.Driver;

namespace ChatSignalR.Mongo
{
    public interface IChatContext
    {
        IMongoCollection<Chat> Chats { get; }
    }
}
