namespace GMS.Common.Options;

public class RabbitMQOptions
{
    public const string Position = "RabbitMQOptions";

    public string Host { get; set; }
    public string VirtualHost { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
}
