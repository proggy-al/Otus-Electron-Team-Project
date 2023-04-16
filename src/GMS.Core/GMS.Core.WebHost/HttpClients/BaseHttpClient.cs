using System.Text.Json;
using Microsoft.Extensions.Options;
using GMS.Core.WebHost.Configurations.Options;
using GMS.Core.WebHost.HttpClients.Abstractions;

namespace GMS.Core.WebHost.HttpClients
{
    public class BaseHttpClient : IBaseHttpClient
    {
        public string? Token
        {
            set
            {
                if(value != null)
                    _httpClient.DefaultRequestHeaders.Add("Authorization", value);
            }
        }

        protected readonly HttpClient _httpClient;
        protected readonly JsonSerializerOptions _options;

        public BaseHttpClient(HttpClient httpClient, IOptions<HttpClientOptions> options)
        {
            _httpClient = httpClient;
            _httpClient.Timeout = TimeSpan.FromSeconds(options.Value.Timeout);
            _httpClient.DefaultRequestHeaders.Clear();

            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }
    }
}
