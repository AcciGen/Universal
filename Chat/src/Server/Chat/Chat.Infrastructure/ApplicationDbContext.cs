using Chat.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Chat.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
            => Database.Migrate();

        public DbSet<Message> Messages { get; set; }
        public DbSet<Domain.Entities.Chat> Chats { get; set; }
    }
}
