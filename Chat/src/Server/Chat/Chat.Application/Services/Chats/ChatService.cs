using Chat.Application.DataTransferObjects.Chats;
using Chat.Application.Services.Helpers;
using Chat.Domain.Enums;
using Chat.Domain.Exxceptions;
using Chat.Infrastructure.Repositories.Chats;

namespace Chat.Application.Services.Chats
{
    public class ChatService : IChatService
    {
        private readonly IChatRepository _chatRepository;
        private readonly IPasswordHasher _passwordHasher;

        public ChatService(IChatRepository chatRepository, IPasswordHasher passwordHasher)
        {
            _chatRepository = chatRepository;
            _passwordHasher = passwordHasher;
        }

        public async ValueTask<Chat.Domain.Entities.Chat> AddChatAsync(long user1Id, long user2Id, ChatType type)
        {
            var chat = new Chat.Domain.Entities.Chat()
            {
                CreatedDate = DateTime.UtcNow,
                Type = type,
                Link = CreateLink(user1Id, user2Id)
            };

            chat = await _chatRepository.AddAsync(chat);

            return chat;
        }

        private string CreateLink(long user1Id, long user2Id)
        {
            var kichik = user1Id < user2Id ? user1Id : user2Id;
            var katta = user1Id > user2Id ? user1Id : user2Id;
            var linkstring = _passwordHasher.Encrypt(kichik.ToString(), katta.ToString());

            return linkstring;
        }

        public async ValueTask<Domain.Entities.Chat> AddGroupAsync(long ownerId)
        {
            return await AddChatAsync(ownerId, ownerId, ChatType.Group);
        }

        public async ValueTask<Domain.Entities.Chat> AddChannelAsync(long ownerId)
        {
            return await AddChatAsync(ownerId, ownerId, ChatType.Channel);
        }

        public async ValueTask<Domain.Entities.Chat> AddPersonalChatAsync(long chat1Id, long chat2Id)
        {
            return await AddChatAsync(chat1Id, chat2Id, ChatType.OneToOne);
        }

        public async ValueTask<Domain.Entities.Chat> GetChatAsync(Guid chatId)
        {
            return await _chatRepository.GetByIdAsync(chatId);
        }

        public async ValueTask<List<Domain.Entities.Chat>> GetChatsAsync(long userId)
        {
            return _chatRepository.GetAll()
                .Where(x => x.Users.Select(x => x.UserId).Contains(userId)).ToList();
        }

        public async ValueTask<Domain.Entities.Chat> DeleteChatAsync(Guid id)
        {
            var chat = await _chatRepository.GetByIdAsync(id);
            if (chat is null)
                throw new NotFoundException("Chat not found");

            return await _chatRepository.RemoveAsync(chat);
        }

        public async ValueTask<List<Domain.Entities.Chat>> GetChatsAsync()
        {
            return _chatRepository.GetAll().ToList();
        }

        public ValueTask<Domain.Entities.Chat> UpdateChatAsync(ChatModificationDTO chatModificationDTO)
        {
            throw new NotImplementedException();
        }
    }
}
