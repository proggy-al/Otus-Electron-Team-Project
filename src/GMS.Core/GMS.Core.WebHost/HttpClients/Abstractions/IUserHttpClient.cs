using GMS.Core.WebHost.Models.Identity;

namespace GMS.Core.WebHost.HttpClients.Abstractions
{
    public interface IUserHttpClient : IBaseHttpClient
    {
        /// <summary>
        /// GET запрос информации о пользователях
        /// </summary>
        /// <returns>список пользователей</returns>
        Task<List<UserApiModel>> GetUsersAsync(List<Guid> userIds);

        /// <summary>
        /// GET запрос короткой информации о пользователях
        /// </summary>
        /// <returns>список пользователей</returns>
        Task<List<UserApiShortModel>> GetShortInfoUsersAsync(List<Guid> ids);

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
