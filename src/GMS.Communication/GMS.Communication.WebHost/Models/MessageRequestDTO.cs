using GMS.Communication.Core;

namespace GMS.Communication.WebHost.Models
{
    public class MessageRequestDTO
    {
        public Guid RecipientId { get; set; }
        public Guid SenderId { get; set; }        
        public string Subject { get; set; }        
        public string Body { get; set; }
        public string Type { get; set; }
        public string CreateDate { get; set;}
        public string DeliveryDate { get; set;}
        public string ReadDate { get; set;}
        public string Status { get; set; }
    }
}
