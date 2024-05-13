using Chat.Application.DataTransferObjects;
using Chat.Domain.Entities;
using Chat.Infrastructure.Repositories.Chats;
using Mapster;

namespace Chat.Application.Services.Chats
{
    public class ChatService : IChatService
    {
        private readonly IChatRepository _chatRepository;

        public ChatService(IChatRepository chatRepository)
            => _chatRepository = chatRepository;

        public async ValueTask<Message> AddMessageAsync(MessageCreationDTO messageCreationDTO)
        {
            var message = messageCreationDTO.Adapt<Message>();
            return message;
        }

        public ValueTask<Message> DeleteMessageAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<Message> GetMessageAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<List<Message>> GetMessagesAsync()
        {
            throw new NotImplementedException();
        }

        public ValueTask<Message> UpdateMessageAsync(MessageModificationDTO messageModificationDTO)
        {
            throw new NotImplementedException();
        }
    }
}
