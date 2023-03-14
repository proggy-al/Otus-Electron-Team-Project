namespace GMS.Communication.Core;

public enum MessageType
{
    Unknown = 0,
    Text = 1,
}

public enum MesseageStatus
{
    none = 0,
    undelivered = 1,
    delivered = 2,
    unread = 3,
    read = 4,
}
