namespace GMS.Core.WebHost.Models
{
    public class EmployeeCreateRequest
    {
        /// <summary>
        /// Идентификатор фитнес клуба
        /// </summary>
        public Guid FitnessClubId { get; set; }

        /// <summary>
        /// Имя пользователя 
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// публичное имя пользователя в telegram. Символы a-z,0-9,_. Минимальная длина 5 символов
        /// </summary>
        public string TelegramUserName { get; set; }

        /// <summary>
        /// Адрес электронной почты
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Пароль повторно
        /// </summary>
        public string ConfirmPassword { get; set; }
     
        /// <summary>
        /// Роль
        /// </summary>
        public string Role { get; set; }
    }
}
