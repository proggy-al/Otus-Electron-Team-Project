using GMS.Core.WebHost.Models.Identity;
using System.Text.Json;
using System.Text;
using Microsoft.Extensions.Options;
using System;
using GMS.Core.WebHost.Configurations.Options;

namespace GMS.Core.WebHost.HttpClients
{
    public class UserHttpClient : IUserHttpClient
    {
        public string? Token
        {
            set
            {
                if(value != null)
                    _httpClient.DefaultRequestHeaders.Add("Authorization", value);
            }
        }

        private HttpClient _httpClient;
        private readonly JsonSerializerOptions _options;

        public UserHttpClient(HttpClient httpClient, IOptions<HttpClientOptions> options)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(options.Value.BaseUriIdentityUser);
            _httpClient.Timeout = TimeSpan.FromSeconds(options.Value.Timeout);
            _httpClient.DefaultRequestHeaders.Clear();

            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<List<UserApiModel>> GetPagedUsersAsync(List<Guid> ids)
        {
            var query = $"?ids={string.Join("&ids=",ids)}";
            var response = await _httpClient.GetAsync($"ids{query}");

            if (!response.IsSuccessStatusCode)
                throw new Exception($"Error request to IdentityService: {response.StatusCode}");    // ToDo: создать custom exception для middleWare

            var result = await response.Content.ReadFromJsonAsync<List<UserApiModel>>();
            return result;
        }

        public async Task<UserApiModel> GetUserAsync(Guid id)
        {
            var response = await _httpClient.GetAsync(id.ToString());
            
            if (!response.IsSuccessStatusCode)
                throw new Exception($"Error request to IdentityService: {response.StatusCode}");    // ToDo: создать custom exception для middleWare

            var result = await response.Content.ReadFromJsonAsync<UserApiModel>();
            return result;
        }

        public async Task<Guid> CreateUserAsync(UserCreateApiModel user)
        {
            var userJson = JsonSerializer.Serialize(user);
            var requestContent = new StringContent(userJson, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("", requestContent);

            if (!response.IsSuccessStatusCode)
                throw new Exception($"Error request to IdentityService: {response.StatusCode}");

            var content = await response.Content.ReadAsStringAsync();
            var createdUser = JsonSerializer.Deserialize<UserApiModel>(content, _options);

            return createdUser.Id;
        }
    }
}
