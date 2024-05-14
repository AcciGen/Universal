using Chat.Domain.Entities;
using Chat.Domain.Exxceptions;
using Chat.Infrastructure.Repositories.ChatUsers;

namespace Chat.Application.Services.ChatUsers
{
    public class ChatUsersService : IChatUsersService
    {
        private readonly IChatUserRepository _chatUserRepository;

        public ChatUsersService(IChatUserRepository chatUserRepository)
            => _chatUserRepository = chatUserRepository;

        public async ValueTask<ChatUser> AddChatUser(ChatUser chatUser)
            => await _chatUserRepository.AddAsync(chatUser);

        public async ValueTask<List<ChatUser>> GetAllConnections()
            => _chatUserRepository.GetAll().ToList();

        public async ValueTask JoinChatAsync(Guid chatId, long userId)
        {
            await _chatUserRepository.AddAsync(new Domain.Entities.ChatUser()
            {
                ChatId = chatId,
                UserId = userId
            });
        }

        public async ValueTask LeaveChatAsync(Guid chatId, long userId)
        {
            var chatUser = _chatUserRepository.GetAll().FirstOrDefault(x => x.ChatId == chatId && x.UserId == userId);

            if (chatUser is null)
                throw new NotFoundException("ChatUser not found");

            await _chatUserRepository.RemoveAsync(new Domain.Entities.ChatUser());
        }
    }
}
