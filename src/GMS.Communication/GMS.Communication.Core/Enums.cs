namespace GMS.Communication.Core;

public enum MessageType
{
    unknown = 0,
    text = 1,
}

public enum MessageStatus
{
    none = 0,
    undelivered = 1,
    delivered = 2,
    unread = 3,
    read = 4,
}
