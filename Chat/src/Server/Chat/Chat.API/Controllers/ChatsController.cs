using Chat.Application.Services.Chats;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Chat.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatsController : ControllerBase
    {
        private readonly IChatService _chatService;

        public ChatsController(IChatService chatService)
            => _chatService = chatService;

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetChats()
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var chats = await _chatService.GetChatsAsync(long.Parse(userId));

            return Ok(chats);
        }

        [HttpPost]
        public async Task<IActionResult> AddChat(long user1Id, long user2Id)
        {
            return Ok(await _chatService.AddPersonalChatAsync(user1Id, user2Id));
        }
    }
}
