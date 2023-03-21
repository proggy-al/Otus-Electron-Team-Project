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
            IdentityServiceAuthorize,
            CommunicationServiceSendMessage
            
        };

        #region Примеры для демонстрации
        private static async void CommunicationServiceSendMessage()
        {
            System.Console.WriteLine("Демонстрация работы CommunicationService:");
            var connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7090/ChatHub") //TODO: поменять https  на http  и порт из docker-compose прописать или через apigateway рфботать- ручкапорт соответствующая
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
                client.BaseAddress = new Uri("http://localhost:4001");

                var cont = new Credential();
                var json = JsonConvert.SerializeObject(cont);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var result = await client.PostAsync("/authorize", data);
                string resultContent = await result.Content.ReadAsStringAsync();
                System.Console.WriteLine(resultContent);
            }

            System.Console.ReadLine();
        }


        #endregion
    }
}
