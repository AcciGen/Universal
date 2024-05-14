using Chat.Application.Services.ChatUsers;
using Microsoft.AspNetCore.Mvc;

namespace Chat.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatUsersController : ControllerBase
    {
        private readonly IChatUsersService _chatUsersService;

        public ChatUsersController(IChatUsersService chatUsersService)
            => _chatUsersService = chatUsersService;

        [HttpGet]
        public async ValueTask<IActionResult> GetAllConnection()
            => Ok(await _chatUsersService.GetAllConnections());

        [HttpPost]
        public async ValueTask<IActionResult> AddConnection(Guid chatId, long userId)
        {
            await _chatUsersService.JoinChatAsync(chatId, userId);
            return Ok();
        }
    }
}
