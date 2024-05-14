namespace Chat.Application.DataTransferObjects
{
    public class MessageCreationDTO
    {
        public Guid ChatId { get; set; }
        public string Text { get; set; }
    }
}
