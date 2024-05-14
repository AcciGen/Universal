using Chat.Domain.Entities;
using Chat.Infrastructure.Repositories.Base;

namespace Chat.Infrastructure.Repositories.Messages
{
    public interface IMessageRepository : IBaseRepository<Message, Guid>
    {
    }
}
