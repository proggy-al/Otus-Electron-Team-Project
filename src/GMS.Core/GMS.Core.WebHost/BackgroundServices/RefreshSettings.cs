namespace GMS.Core.WebHost.BackgroundServices
{
    /// <summary>
    /// Настройки для сервиса по обновлению значений из переменых среды
    /// </summary>
    public class RefreshSettings
    {
        /// <summary>
        /// Интервал обновления
        /// </summary>
        public TimeSpan IntervalRefresh { get; set; }
    }
}
