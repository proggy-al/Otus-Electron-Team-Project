using Microsoft.AspNetCore.SignalR.Client;
using System.Text;
using System;
using Newtonsoft.Json;
using System.Collections.Specialized;
using GMS.Gui.Console.DTO;

namespace GMS.Gui.Console
{
    /// <summary>
    /// Примеры функциональности
    /// </summary>
    public static class ExamplesFunctionality
    {
        /// <summary>
        /// Получить список делегатов примеров.
        /// </summary>
        /// <returns></returns>
        public static List<Action> GetActions() => new List<Action>
        {
            CommunicationServiceSendMessage,
            //IdentityServiceAuthorize
        };

        #region Примеры для демонстрации
        private static async void CommunicationServiceSendMessage()
        {
            System.Console.WriteLine("Демонстрация работы CommunicationService:");
            var resultContent = string.Empty;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5225");

                var cont = new Credential();
                var json = JsonConvert.SerializeObject(cont);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                
                var result = await client.PostAsync("/user/authorize", data);
                resultContent = await result.Content.ReadAsStringAsync();
                System.Console.WriteLine(resultContent);               
            }

            var connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5225/ChatHub",
                configureHttpConnection: options => options.AccessTokenProvider = () =>
                {
                    return Task.FromResult(resultContent);
                })
                .Build();

            connection.On<string, string>("ReceiveMessage", (message, userId) => System.Console.WriteLine($"{userId}:{message}"));

            

            // Loop is here to wait until the server is running
            while (true)
            {
                try
                {
                    await connection.StartAsync();
                    System.Console.WriteLine("Ожидание сообщения сообщения от сервера...");
                    break;
                }
                catch (Exception e)
                {
                    System.Console.WriteLine("Ошибка:" + e.Message);
                }
            }
            System.Console.ReadLine();
            // Code of functionality exmaple.
        }

        private static async void IdentityServiceAuthorize()
        {
            System.Console.WriteLine("Демонстрация работы IdentityService:");

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:7118");

                var cont = new Credential();
                var json = JsonConvert.SerializeObject(cont);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                
                var result = await client.PostAsync("/user/authorize", data);
                string resultContent = await result.Content.ReadAsStringAsync();
                System.Console.WriteLine(resultContent);
            }

            System.Console.ReadLine();
        }


        #endregion
    }
}
