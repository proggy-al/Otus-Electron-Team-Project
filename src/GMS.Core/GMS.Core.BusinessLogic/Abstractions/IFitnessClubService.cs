using GMS.Core.BusinessLogic.Abstractions.Base;
using GMS.Core.BusinessLogic.Contracts;
using GMS.Core.Core.Domain;
using GMS.Core.DataAccess.Repositories;

namespace GMS.Core.BusinessLogic.Abstractions
{
    public interface IFitnessClubService : IBaseService<FitnessClubRepository, FitnessClub, FitnessClubDto, Guid>
    {
        /// <summary>
        /// Получить список
        /// </summary>
        /// <param name="page">номер страницы</param>
        /// <param name="itemsPerPage">объем страницы</param>
        /// <returns>список ДТО фитнес клуба</returns>
        Task<List<FitnessClubDto>> GetPage(int page, int itemsPerPage);
    }
}
