using GMS.Core.BusinessLogic.Contracts;
using GMS.Core.WebHost.Models;

namespace GMS.Core.BusinessLogic.Abstractions
{
    public interface IProductService : IService
    {
        /// <summary>
        /// Получить список продуктов клуба
        /// </summary>
        /// <param name="fitnessClubId">идентификатор фитнес клуба</param>
        /// <param name="pageNumber">номер страницы</param>
        /// <param name="pageSize">количество</param>
        /// <returns>список ДТО продуктов</returns>
        Task<PagedList<ProductDto>> GetPage(Guid fitnessClubId, int pageNumber, int pageSize);

        /// <summary>
        /// Получить
        /// </summary>
        /// <param name="id">идентификатор</param>
        /// <returns>ДТО продукта</returns>
        Task<ProductDto> Get(Guid id);

        /// <summary>
        /// Создать
        /// </summary>
        /// <param name="dto">ДТО</para
        /// <returns>идентификатор</returns>
        Task<Guid> Create(ProductCreateDto dto);

        /// <summary>
        /// Поместить в архив
        /// </summary>
        /// <param name="id">идентификатор</param>
        Task AddToArchive(Guid id, Guid userId);
    }
}
