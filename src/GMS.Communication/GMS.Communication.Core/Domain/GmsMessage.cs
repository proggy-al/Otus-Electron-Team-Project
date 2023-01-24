using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMS.Communication.Core.Abstractons;

namespace GMS.Communication.Core.Domain;

public class GmsMessage : BaseEntity
{
    public Guid RecipientId { get; set; }
    public Guid SenderId { get; set; }
    public string? Body { get; set; }
    public MessageType Type { get; set; }
    public DateTime CreateDate { get; set;}
    public DateTime DeliveryDate { get; set;}
}
