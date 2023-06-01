using GMS.Core.WebHost.Models.Identity;
using System.Text.Json;
using System.Text;
using Microsoft.Extensions.Options;
using System;
using GMS.Core.WebHost.Configurations.Options;
using GMS.Core.WebHost.HttpClients.Abstractions;

namespace GMS.Core.WebHost.HttpClients
{
    public class CoachHttpClient : BaseHttpClient, ICoachHttpClient
    {
        public CoachHttpClient(HttpClient httpClient, IOptions<HttpClientOptions> options) : base(httpClient, options)
        {
            _httpClient.BaseAddress = new Uri(options.Value.BaseUriIdentityCoach);
        }

        public async Task<List<UserApiShortModel>> GetPagedCoachesAsync(List<Guid> ids)
        {
            var query = $"?ids={string.Join("&ids=",ids)}";
            var response = await _httpClient.GetAsync($"ids{query}");

            if (!response.IsSuccessStatusCode)
                throw new Exception($"Error request to IdentityService: {response.StatusCode}");    // ToDo: создать custom exception для middleWare

            var result = await response.Content.ReadFromJsonAsync<List<UserApiShortModel>>();
            return result;
        }
    }
}
