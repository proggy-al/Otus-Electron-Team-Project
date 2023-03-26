using GMS.Communication.Core;
using GMS.Communication.Core.Domain;

namespace GMS.Communication.DataAccess.Data
{
    public static class TestData
    {
        public static List<GmsMessage> Messages = new List<GmsMessage>()
        {
            new GmsMessage()
            {
                RecipientId = new Guid(),
                SenderId = new Guid(),
                Subject = "TestSubject1",
                Body = "TestBody1",
                Type = MessageType.text,
                Status = MessageStatus.read,
            },
            new GmsMessage()
            {
                RecipientId = new Guid(),
                SenderId = new Guid(),
                Subject = "TestSubject2",
                Body = "TestBody2",
                Type = MessageType.text,
                Status = MessageStatus.undelivered,
            },
            new GmsMessage()
            {
                RecipientId = new Guid(),
                SenderId = new Guid(),
                Subject = "TestSubject3",
                Body = "TestBody3",
                Type = MessageType.text,
                Status = MessageStatus.unread,
            }
        };
    }
}
