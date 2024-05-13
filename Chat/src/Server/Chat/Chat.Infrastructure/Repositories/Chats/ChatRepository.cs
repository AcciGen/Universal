using Chat.Infrastructure.Repositories.Base;

namespace Chat.Infrastructure.Repositories.Chats
{
    public class ChatRepository : BaseRepository<Domain.Entities.Chat>, IChatRepository
    {
        public ChatRepository(ApplicationDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
