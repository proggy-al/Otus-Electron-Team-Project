using GMS.Communication.Core.Abstractons;


namespace GMS.Communication.Core.Domain;

public class GmsMessage : BaseEntity
{
    public Guid RecipientId { get; set; }
    public Guid SenderId { get; set; }
    public string Subject { get; set; } = null!;
    public string Body { get; set; } = null!;
    public MessageType Type { get; set; }
    public DateTime CreateDate { get; set;}
    public DateTime DeliveryDate { get; set;}
    public DateTime ReadDate { get; set;}
    public MessageStatus Status { get; set; }
}