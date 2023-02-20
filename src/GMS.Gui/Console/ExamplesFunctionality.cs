using Console = System.Console;

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
            CommunicationServiceSendById,
        };

        #region Примеры для демонстрации
        private static void CommunicationServiceSendById()
        {
            System.Console.WriteLine("Пример №1:\nCommunicationService метод отправить сообщение адресату по id");
            // Code of functionality exmaple.
        }
        #endregion
    }
}
