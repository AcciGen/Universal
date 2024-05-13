using Chat.Infrastructure.Repositories.Messages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;

namespace Chat.API.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        private readonly IMessageRepository _messageRepository;

        public ChatHub(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task SendMessage(string message)
        {
            var userId = Context.User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _messageRepository.AddAsync(new Domain.Entities.Message()
            {
                SenderId = long.Parse(userId),
                Text = message,
                CreatedDate = DateTime.UtcNow,
            });

            var firstName = Context.User.FindFirstValue(ClaimTypes.Name);

            await Clients.All.SendAsync("ReceiveMessage", userId, message);
        }
    }
}
