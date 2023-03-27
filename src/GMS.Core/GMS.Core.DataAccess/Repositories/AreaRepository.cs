﻿using GMS.Core.Core.Abstractions.Repositories;
using GMS.Core.DataAccess.Repositories.Base;
using GMS.Core.Core.Domain;
using Microsoft.EntityFrameworkCore;
using GMS.Core.DataAccess.Context;

namespace GMS.Core.DataAccess.Repositories
{
    /// <summary>
    /// Репозиторий зоны
    /// </summary>
    public class AreaRepository : Repository<Area, Guid>, IAreaRepository
    {
        public AreaRepository(DatabaseContext context) : base(context) { }

        /// <summary>
        /// Получить постраничный список
        /// </summary>
        /// <param name="pageNumber">номер страницы</param>
        /// <param name="pageSize">объем страницы</param>
        /// <returns>список зон</returns>
        public async Task<List<Area>> GetPagedAsync(int pageNumber, int pageSize)
        {
            var query = GetAll();
            return await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        /// <summary>
        /// Получить все сущности по идентификатору фитнес клуба 
        /// </summary>
        /// <param name="fitnessClubId">идентификатор фитнес клуба</param>
        /// <returns>список зон</returns>
        public async Task<List<Area>> GetAllByFitnessClubIdAsync(Guid fitnessClubId)
        {
            var query = GetAll();
            return await query
                .Where(a => a.FitnessClubId == fitnessClubId)
                .ToListAsync();
        }

        /// <summary>
        /// Получить постраничный список по идентификатору фитнес клуба 
        /// </summary>
        /// <param name="fitnessClubId">идентификатор фитнес клуба</param>
        /// <param name="pageNumber">номер страницы</param>
        /// <param name="pageSize">объем страницы</param>
        /// <returns>список зон</returns>
        public async Task<List<Area>> GetPagedByFitnessClubIdAsync(Guid fitnessClubId, int pageNumber, int pageSize)
        {
            var query = GetAll();
            return await query
                .Where(a => a.FitnessClubId == fitnessClubId)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}
