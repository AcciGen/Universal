using Chat.Domain.Entities;
using Chat.Infrastructure.Repositories.Base;

namespace Chat.Infrastructure.Repositories.Messages
{
    public class MessageRepository : BaseRepository<Message>, IMessageRepository
    {
        public MessageRepository(ApplicationDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
