namespace GMS.Core.WebHost.Configurations.Options
{
    public class HttpClientOptions
    {
        public const string Position = "HttpClientOptions";

        public string BaseUriIdentityUser { get; set; }

        public int Timeout { get; set; }
    }
}
