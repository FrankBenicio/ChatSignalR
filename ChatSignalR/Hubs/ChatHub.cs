using ChatSignalR.Models;
using ChatSignalR.Mongo;
using Microsoft.AspNetCore.SignalR;

namespace ChatSignalR.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IChatRepository _repo;

        public ChatHub(IChatRepository repo)
        {
            _repo = repo;
        }

        public async Task SendMessage(string user, string message)
        {
            var id = await _repo.GetNextId();

            var chat = new Chat(id, user, message);

            await _repo.Create(chat);

            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
