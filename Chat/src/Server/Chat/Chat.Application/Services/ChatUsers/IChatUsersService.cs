namespace Chat.Application.Services.ChatUsers
{
    public interface IChatUsersService
    {
        ValueTask JoinChatAsync(Guid chatId, long userId);
        ValueTask LeaveChatAsync(Guid chatId, long userId);
        ValueTask<List<Chat.Domain.Entities.ChatUser>> GetAllConnections();
    }
}
