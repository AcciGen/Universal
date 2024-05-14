using Chat.Application.DataTransferObjects.Chats;
using Chat.Domain.Enums;

namespace Chat.Application.Services.Chats
{
    public interface IChatService
    {
        ValueTask<Chat.Domain.Entities.Chat> AddChatAsync(long chat1Id, long chat2Id, ChatType type);
        ValueTask<Chat.Domain.Entities.Chat> AddGroupAsync(long ownerId);
        ValueTask<Chat.Domain.Entities.Chat> AddChannelAsync(long ownerId);
        ValueTask<Chat.Domain.Entities.Chat> AddPersonalChatAsync(long chat1Id, long chat2Id);
        ValueTask<Chat.Domain.Entities.Chat> GetChatAsync(Guid id);
        ValueTask<List<Chat.Domain.Entities.Chat>> GetChatsAsync(long userId);
        ValueTask<List<Chat.Domain.Entities.Chat>> GetChatsAsync();
        ValueTask<Chat.Domain.Entities.Chat> UpdateChatAsync(ChatModificationDTO chatModificationDTO);
        ValueTask<Chat.Domain.Entities.Chat> DeleteChatAsync(Guid id);
    }
}
