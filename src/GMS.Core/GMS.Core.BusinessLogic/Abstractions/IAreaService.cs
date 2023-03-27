using GMS.Core.BusinessLogic.Contracts;

namespace GMS.Core.BusinessLogic.Abstractions
{
    public interface IAreaService : IService
    {
        /// <summary>
        /// Получить постраничный список зон
        /// </summary>
        /// <param name="fitnessClubId">идентификатор фитнес клуба</param>
        /// <param name="pageNumber">номер страницы</param>
        /// <param name="pageSize">количество</param>
        /// <returns>список ДТО зон</returns>
        Task<List<AreaDto>> GetPage(Guid fitnessClubId, int pageNumber, int pageSize);
    }
}
