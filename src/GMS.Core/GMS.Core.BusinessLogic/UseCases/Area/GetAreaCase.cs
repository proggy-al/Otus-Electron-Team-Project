using AutoMapper;
using GMS.Core.BusinessLogic.Contracts;
using GMS.Core.DataAccess.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Text;

namespace GMS.Core.BusinessLogic.UseCases.Area
{
    public  class GetAreaCase : IRequest<IEnumerable<AreaDto>>
    {
        public GetAreaCase(Guid fitnessClubId, int page, int pageSize)
        {
            FitnessClubId = fitnessClubId;
            Page = page;
            PageSize = pageSize;
        }

        public Guid FitnessClubId { get; set; }

        public int Page { get; set; }
        public int PageSize { get; set; }
    }


    public class GetAreaCaseHandler : IRequestHandler<GetAreaCase, IEnumerable<AreaDto>>
    {
        private readonly ILogger<GetAreaCaseHandler> _logger;
        private readonly DatabaseContext _db;
        private readonly IMapper _mapper;

        public GetAreaCaseHandler(ILogger<GetAreaCaseHandler> logger,
            DatabaseContext db,
            IMapper mapper)
        {
            _logger = logger;
            _db = db;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AreaDto>> Handle(GetAreaCase request, CancellationToken cancellationToken)
        {
            try
            {
                var query = _db.Areas.AsQueryable();
                if(request.FitnessClubId != Guid.Empty)
                {
                    query = query.Where(e => e.FitnessClubId == request.FitnessClubId);
                }

                if(request.Page != 0 && request.PageSize != 0)
                {
                    var skip = (request.Page - 1) * request.PageSize;
                    query = query.Skip(skip).Take(request.PageSize);
                }

                var entities = await query.ToListAsync();

                return entities.Select(e => _mapper.Map<AreaDto>(e));

            }
            catch (Exception ex)
            {
                _logger.LogError($"{{\"Message\": \"{ex.Message}\", \"Inner exception\": \"{ex.InnerException}\" }}");
                throw;
            }
        }
    }
}
