using Chat.Infrastructure.Repositories.Base;

namespace Chat.Infrastructure.Repositories.Chats
{
    public interface IChatRepository : IBaseRepository<Domain.Entities.Chat, Guid>
    {
    }
}
