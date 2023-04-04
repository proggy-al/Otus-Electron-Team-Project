

using GMS.Identity.Client.Models;

namespace GMS.Identity.Core.Abstractions.Repositories
{
    public interface IUserRepository
    {
        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>UserApiModel</returns>
        public Task<UserApiModel?> GetUser(Guid id);

        /// <summary>
        /// Get list UserApiModel
        /// </summary>
        /// <param name="ids">list ids</param>
        /// <returns>List UserApiModel</returns>
        Task<List<UserApiModel>> GetListUsers(List<Guid> ids);

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns>UserApiModel</returns>
        public Task<List<UserApiModel>> GetUsers();

        /// <summary>
        /// Add new user
        /// </summary>
        /// <param name="createApiModel">new user</param>
        /// <returns>UserApiModel</returns>
        public Task<UserApiModel> CreateAsync(UserCreateApiModel createApiModel);


        /// <summary>
        /// Update user by id
        /// </summary>
        /// <param name="user">user</param>
        /// <returns></returns>
        public Task<bool> PatchAsync(Guid id, UserPatchApiModel user);
    
        /// <summary>
        /// Delete user by id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        public Task<bool> DeleteAsync(Guid id);

        /// <summary>
        /// Authorize user by name and pass
        /// </summary>
        /// <param name="user">user</param>
        /// <returns></returns>
        public Task<UserJwtTokenModel> AuthorizeUser(UserAuthorizeApiModel user);


    }
}
