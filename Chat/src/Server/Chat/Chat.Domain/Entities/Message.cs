namespace Chat.Domain.Entities
{
    public class Message
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public long SenderId { get; set; }
        public Guid ChatId { get; set; }
        public DateTimeOffset CreatedDate { get; set; }

        public virtual Chat Chat { get; set; }
    }
}
