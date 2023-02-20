using Microsoft.AspNetCore.SignalR.Client;

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
        };

        #region Примеры для демонстрации
        private static async void CommunicationServiceSendMessage()
        {
            System.Console.WriteLine("Демонстрация работы CommunicationService:");
            var connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:44361/ChatHub")
                .Build();

            connection.On<string, string>("ReceiveMessage", (message, userId) => System.Console.WriteLine($"{userId}:{message}"));

            // Loop is here to wait until the server is running
            while (true)
            {
                try
                {
                    await connection.StartAsync();
                    break;
                }
                catch
                {
                    await Task.Delay(1000);
                }
            }

            System.Console.WriteLine("Ожидание сообщения сообщения от сервера...");
            System.Console.ReadLine();
            // Code of functionality exmaple.
        }
        #endregion
    }
}
