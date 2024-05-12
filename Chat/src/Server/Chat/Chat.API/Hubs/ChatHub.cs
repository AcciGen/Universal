using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;

namespace Chat.API.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            var userId = Context.User.FindFirstValue(ClaimTypes.NameIdentifier);
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
