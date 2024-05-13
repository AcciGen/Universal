using Chat.Application.DataTransferObjects;
using Chat.Domain.Entities;

namespace Chat.Application.Services.Chats
{
    public interface IChatService
    {
        ValueTask<Message> AddMessageAsync(MessageCreationDTO messageCreationDTO);
        ValueTask<Message> GetMessageAsync(Guid id);
        ValueTask<List<Message>> GetMessagesAsync();
        ValueTask<Message> UpdateMessageAsync(MessageModificationDTO messageModificationDTO);
        ValueTask<Message> DeleteMessageAsync(Guid id);
    }
}
