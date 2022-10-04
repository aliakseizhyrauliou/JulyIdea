using Microsoft.AspNetCore.SignalR;

namespace JulyIdea.Services.MessangerAPI.SignalRHub
{
    public class CustomUserIdProvider : IUserIdProvider
    {
        public string GetUserId(HubConnectionContext connection)
        {
            return connection.User?.Claims.SingleOrDefault(x => x.Type == "Id").Value;
        }
    }
}
