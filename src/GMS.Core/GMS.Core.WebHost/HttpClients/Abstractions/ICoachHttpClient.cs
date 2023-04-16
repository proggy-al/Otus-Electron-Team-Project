using GMS.Core.WebHost.Models.Identity;

namespace GMS.Core.WebHost.HttpClients.Abstractions
{
    public interface ICoachHttpClient : IBaseHttpClient
    {
        /// <summary>
        /// GET запрос информации о тренерах
        /// </summary>
        /// <returns>список тренеров</returns>
        Task<List<UserApiShortModel>> GetPagedCoachesAsync(List<Guid> coachIds);
    }
}
