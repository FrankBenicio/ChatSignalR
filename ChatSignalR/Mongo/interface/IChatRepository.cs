using ChatSignalR.Models;

namespace ChatSignalR.Mongo
{
    public interface IChatRepository
    {
        Task<IEnumerable<Chat>> GetAllChats();

        Task<Chat> GetChat(long id);

        Task Create(Chat chat);

        Task<Chat> GetLastMessage();
        Task<long> GetNextId();
    }
}
