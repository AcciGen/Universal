using Chat.Domain.Enums;

namespace Chat.Domain.Entities
{
    public class Chat
    {
        public Guid Id { get; set; }
        public ChatType Type { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
    }
}
