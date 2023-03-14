namespace GMS.Communication.WebHost.Models
{
    public class MessageRequestDTO
    {
        public Guid RecipientId { get; set; }
        public Guid SenderId { get; set; }        
        public string Subject { get; set; }        
        public string Body { get; set; }
        public string Type { get; set; }
        public DateTime CreateDate { get; set;}
        public DateTime DeliveryDate { get; set;}
        public string Status { get; set; }
    }
}
