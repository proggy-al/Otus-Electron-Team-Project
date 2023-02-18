using GMS.Core.BusinessLogic.Abstractions.Base;
using GMS.Core.BusinessLogic.Contracts;
using GMS.Core.Core.Domain;
using GMS.Core.DataAccess.Repositories;

namespace GMS.Core.BusinessLogic.Abstractions
{
    public interface IProductService : IBaseService<ProductRepository, Product, ProductDto, Guid>
    {
        /// <summary>
        /// Получить список
        /// </summary>
        /// <param name="page">номер страницы</param>
        /// <param name="itemsPerPage">объем страницы</param>
        /// <returns>список ДТО продукта</returns>
        Task<List<ProductDto>> GetPage(int page, int itemsPerPage);

        /// <summary>
        /// Получить все сущности по идентификатору фитнес клуба 
        /// </summary>
        /// <param name="fitnessClubId">идентификатор фитнес клуба</param>
        /// <returns>список ДТО продуктов</returns>
        Task<List<ProductDto>> GetAllByFitnessClubId(Guid fitnessClubId);

        /// <summary>
        /// Получить постраничный список по идентификатору фитнес клуба 
        /// </summary>
        /// <param name="fitnessClubId">идентификатор фитнес клуба</param>
        /// <param name="page">номер страницы</param>
        /// <param name="itemsPerPage">объем страницы</param>
        /// <returns>список ДТО продуктов</returns>
        Task<List<ProductDto>> GetPageByFitnessClubId(Guid fitnessClubId, int page, int itemsPerPage);
    }
}
