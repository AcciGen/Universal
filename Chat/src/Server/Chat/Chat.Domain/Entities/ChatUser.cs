namespace Chat.Domain.Entities
{
    public class ChatUser
    {
        public Guid Id { get; set; }
        public long UserId { get; set; }
        public Guid ChatId { get; set; }
    }
}
