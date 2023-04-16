using GMS.Core.WebHost.Models.Identity;
using System.Text.Json;
using System.Text;
using Microsoft.Extensions.Options;
using GMS.Core.WebHost.Configurations.Options;
using GMS.Core.WebHost.HttpClients.Abstractions;

namespace GMS.Core.WebHost.HttpClients
{
    public class UserHttpClient : BaseHttpClient, IUserHttpClient
    {
        public UserHttpClient(HttpClient httpClient, IOptions<HttpClientOptions> options) : base(httpClient,options)
        {
            _httpClient.BaseAddress = new Uri(options.Value.BaseUriIdentityUser);
        }

        public async Task<List<UserApiModel>> GetUsersAsync(List<Guid> ids)
        {
            var query = $"?ids={string.Join("&ids=",ids)}";
            var response = await _httpClient.GetAsync($"ids{query}");

            if (!response.IsSuccessStatusCode)
                throw new Exception($"Error request to IdentityService: {response.StatusCode}");    // ToDo: создать custom exception для middleWare

            var result = await response.Content.ReadFromJsonAsync<List<UserApiModel>>();
            return result;
        }

        public async Task<List<UserApiShortModel>> GetShortInfoUsersAsync(List<Guid> ids)
        {
            var query = $"?ids={string.Join("&ids=", ids)}";
            var response = await _httpClient.GetAsync($"info/ids{query}");

            if (!response.IsSuccessStatusCode)
                throw new Exception($"Error request to IdentityService: {response.StatusCode}");    // ToDo: создать custom exception для middleWare

            var result = await response.Content.ReadFromJsonAsync<List<UserApiShortModel>>();
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
