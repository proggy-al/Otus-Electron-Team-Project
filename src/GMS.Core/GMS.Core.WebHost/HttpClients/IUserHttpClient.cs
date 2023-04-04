using GMS.Core.WebHost.Models.Identity;

namespace GMS.Core.WebHost.HttpClients
{
    public interface IUserHttpClient
    {
        string? Token { set; }

        /// <summary>
        /// GET запрос информации о пользователях
        /// </summary>
        /// <returns>список пользователей</returns>
        Task<List<UserApiModel>> GetPagedUsersAsync(List<Guid> userIds);

        /// <summary>
        /// GET запрос информации о пользователе
        /// </summary>
        /// <param name="id">идентификатор пользователя</param>
        /// <returns>модель пользователья</returns>
        Task<UserApiModel> GetUserAsync(Guid id);

        /// <summary>
        /// POST запрос создания пользователя
        /// </summary>
        /// <param name="user">модель пользователя</param>
        /// <returns>идентификатор пользователя</returns>
        Task<Guid> CreateUserAsync(UserCreateApiModel user);
    }
}
