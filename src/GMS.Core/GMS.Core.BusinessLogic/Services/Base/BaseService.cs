using AutoMapper;
using GMS.Core.BusinessLogic.Abstractions.Base;
using GMS.Core.BusinessLogic.Contracts;
using GMS.Core.Core.Abstractions.Repositories.Base;
using GMS.Core.Core.Domain;

namespace GMS.Core.BusinessLogic.Services.Base
{
    public abstract class BaseService<TRepository, T, TDto, TPrimaryKey> : IBaseService<TRepository, T, TDto, TPrimaryKey>
        where TRepository : IRepository<T, TPrimaryKey>
        where T : IEntity<TPrimaryKey>
        where TDto : class
    {
        protected readonly IMapper _mapper;
        protected readonly TRepository _repository;

        protected BaseService(IMapper mapper, TRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public virtual async Task<TDto> GetById(TPrimaryKey id)
        {
            var entity = await _repository.GetAsync(id);
            return _mapper.Map<TDto>(entity);
        }

        public virtual async Task<TPrimaryKey> Create(TDto dto)
        {
            var entity = _mapper.Map<TDto, T>(dto);
            var result = await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();
            return result.Id;
        }

        public virtual async Task Update(TPrimaryKey id, TDto dto)
        {
            var entity = _mapper.Map<TDto, T>(dto);
            entity.Id = id;
            _repository.Update(entity);
            await _repository.SaveChangesAsync();
        }

        public virtual async Task Delete(TPrimaryKey id)
        {
            var entity = await _repository.GetAsync(id);
            entity.Deleted = true;
            await _repository.SaveChangesAsync();
        }
    }
}
