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
                RecipientId = Guid.Parse("a24ab827-10a5-47bf-86bd-39adeb89b6c9"),
                SenderId = Guid.Parse("8699aba2-5ec1-40cf-b186-36ca13c15ea2"),
                Subject = "TestSubject1",
                Body = "TestBody1",
                Type = MessageType.text,
                Status = MessageStatus.read,
            },
            new GmsMessage()
            {
                RecipientId = Guid.Parse("a24ab827-10a5-47bf-86bd-39adeb89b6c9"),
                SenderId = Guid.Parse("8699aba2-5ec1-40cf-b186-36ca13c15ea2"),
                Subject = "TestSubject2",
                Body = "TestBody2",
                Type = MessageType.text,
                Status = MessageStatus.undelivered,
            },
            new GmsMessage()
            {
                RecipientId = Guid.Parse("8699aba2-5ec1-40cf-b186-36ca13c15ea2"),
                SenderId =Guid.Parse("a24ab827-10a5-47bf-86bd-39adeb89b6c9"),
                Subject = "TestSubject3",
                Body = "TestBody3",
                Type = MessageType.text,
                Status = MessageStatus.unread,
            }
        };
    }
}
