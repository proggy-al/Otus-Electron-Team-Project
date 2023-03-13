using GMS.Communication.Core.Abstractons;
using System.ComponentModel.DataAnnotations;


namespace GMS.Communication.Core.Domain;

public class ChatMessage : BaseEntity
{
    [Required]
    public Guid RecipientId { get; set; }
    [Required]
    public Guid SenderId { get; set; }
    [Required]
    public string Subject { get; set; }
    [Required]
    public string Body { get; set; }
    [Required]
    public MessageType Type { get; set; }
    public DateTime CreateDate { get; set;}
    public DateTime DeliveryDate { get; set;}
    public MesseageStatus Status { get; set; }
}