using Chat.Infrastructure.Repositories.Base;

namespace Chat.Infrastructure.Repositories.ChatUsers
{
    public class ChatUserRepository : BaseRepository<Chat.Domain.Entities.ChatUser, Guid>, IChatUserRepository
    {
        public ChatUserRepository(ApplicationDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
