using Microsoft.AspNetCore.SignalR;

namespace JulyIdea.Services.MessangerAPI.SignalRHub
{
    public class MessagesHub : Hub
    {
        public async Task SendMessage(string text, string userId) 
        {
            await Clients.User(userId).SendAsync("RecieveMessage", text);
        }
    }
}
