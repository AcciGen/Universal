using Chat.Infrastructure.Repositories.Base;

namespace Chat.Infrastructure.Repositories.Chats
{
    public class ChatRepository : BaseRepository<Domain.Entities.Chat, Guid>, IChatRepository
    {
        public ChatRepository(ApplicationDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
