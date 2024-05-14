using Chat.Infrastructure.Repositories.Base;

namespace Chat.Infrastructure.Repositories.ChatUsers
{
    public interface IChatUserRepository : IBaseRepository<Chat.Domain.Entities.ChatUser, Guid>
    {
    }
}
