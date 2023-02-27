using GMS.APIgateway.Test;
using GMS.APIgateway.Utils;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Text;

namespace GMS.APIgateway
{
    public class Router
    {

        public List<Route> Routes { get; set; }
        public Destination AuthenticationService { get; set; }


        public Router(string routeConfigFilePath)
        {
            dynamic router = JsonLoader.LoadFromFile<dynamic>(routeConfigFilePath);

            Routes = JsonLoader.Deserialize<List<Route>>(Convert.ToString(router.routes));
            AuthenticationService = JsonLoader.Deserialize<Destination>(Convert.ToString(router.authenticationService));

        }

        public async Task<HttpResponseMessage> RouteRequest(HttpRequest request)
        {
            string path = request.Path.ToString();
            string basePath = '/' + path.Split('/')[1];

            Destination destination;
            try
            {
                destination = Routes.First(r => r.Endpoint.Equals(basePath)).Destination;
            }
            catch
            {
                return ConstructErrorMessage("The path could not be found.");
            }

            if (destination.RequiresAuthentication)
            {
                string token = request.Headers["token"];

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(AuthenticationService.Path);

                    var cont = new Credential();
                    var json = JsonConvert.SerializeObject(cont);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");

                    var result = await client.PostAsync(AuthenticationService.Path, data);
                    string resultContent = await result.Content.ReadAsStringAsync();

                    token =  JsonLoader.Deserialize<Auth>(resultContent).Token;
                   
                    Debug.WriteLine(resultContent);

                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    return await client.GetAsync(destination.Path);
                }

                
                //request.Query.Append(new KeyValuePair<string, StringValues>("token", new StringValues(token)));
                //HttpResponseMessage authResponse = await AuthenticationService.SendRequest(request);
                //if (!authResponse.IsSuccessStatusCode) return ConstructErrorMessage("Authentication failed.");
            }

            //return await destination.SendRequest(request);
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(destination.Path);

                
                return await client.GetAsync(destination.Path);
            }
        }

        private HttpResponseMessage ConstructErrorMessage(string error)
        {
            HttpResponseMessage errorMessage = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NotFound,
                Content = new StringContent(error)
            };
            return errorMessage;
        }

    }
}
