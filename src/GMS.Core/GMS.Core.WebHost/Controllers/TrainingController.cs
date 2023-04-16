using AutoMapper;
using GMS.Core.BusinessLogic.Abstractions;
using GMS.Core.BusinessLogic.Contracts;
using GMS.Core.WebHost.Controllers.Base;
using GMS.Core.WebHost.HttpClients.Abstractions;
using GMS.Core.WebHost.Models;
using JWTAuthManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace GMS.Core.WebHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingController : BaseController<ITrainingService>
    {
        private ICoachHttpClient _coachHttpClient;
        private IUserHttpClient _userHttpClient;

        public TrainingController(ITrainingService service, IMapper mapper,ICoachHttpClient coachHttpClient, IUserHttpClient userHttpClient) : base(service, mapper) 
        {
            _coachHttpClient = coachHttpClient;
            _userHttpClient = userHttpClient;
        }

        private delegate Task<PagedList<TrainingTrainerDto>> GetPagedByTrainerIdDelegate(Guid trainerId, int pageNumber, int pageSize);

        private async Task<IActionResult> GetPagePastByTrainerId(GetPagedByTrainerIdDelegate getTrainings, int pageNumber, int pageSize)
        {
            var pagedTrainings = await getTrainings(UserId, pageNumber, pageSize);

            if (pagedTrainings.Entities.Count == 0)
                return NoContent();

            // получаем список уникальных Id пользователей
            var uniqUserIds = pagedTrainings.Entities.Select(x => x.UserId).Distinct().ToList();

            // запрашиваем информацию о пользователях в Identity microservice
            _userHttpClient.Token = GetToken();
            var users = await _userHttpClient.GetShortInfoUsersAsync(uniqUserIds);

            // соединяем информацию пользователей с информацией о тренировках
            var trainings = from u in users
                            join t in pagedTrainings.Entities on u.Id equals t.UserId
                            select new TrainingTrainerResponse
                            {
                                Id = t.Id,
                                Name = t.Name,
                                Description = t.Description,
                                DateTime = t.DateTime,
                                Duration = t.Duration,
                                UserName = u.UserName,
                                FitnessClubName = t.FitnessClubName,
                                AreaName = t.AreaName,
                                TrainerNotes = t.TrainerNotes,
                                Points = t.Points,
                            };

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedTrainings.Pagination));
            return Ok(trainings);
        }

        [Authorize(Roles = nameof(Priviliges.Coach))]
        [HttpGet("[action]/{pageNumber}:{pageSize}")]
        public async Task<IActionResult> GetPagePastByTrainerId(int pageNumber = 1, int pageSize = 12)
        {
            return await GetPagePastByTrainerId(_service.GetPagedPastByTrainerId, pageNumber, pageSize);
        }

        [Authorize(Roles = nameof(Priviliges.Coach))]
        [HttpGet("[action]/{pageNumber}:{pageSize}")]
        public async Task<IActionResult> GetPageByTrainerId(int pageNumber = 1, int pageSize = 12)
        {
            return await GetPagePastByTrainerId(_service.GetPagedByTrainerId, pageNumber, pageSize);
        }

        [Authorize(Roles = nameof(Priviliges.User))]
        [HttpGet("[action]/{pageNumber}:{pageSize}")]
        public async Task<IActionResult> GetPageByUserId(int pageNumber = 1, int pageSize = 12)
        {
            var pagedTrainings = await _service.GetPageByUserId(UserId, pageNumber, pageSize);

            if (pagedTrainings.Entities.Count == 0)
                return NoContent();

            // получаем список уникальных Id тренеров
            var uniqTrainersIds = pagedTrainings.Entities.Select(x => x.TrainerId).Distinct().ToList();

            // запрашиваем информацию о тренерах в Identity microservice
            _coachHttpClient.Token = GetToken();
            var coaches = await _coachHttpClient.GetPagedCoachesAsync(uniqTrainersIds);

            // соединяем информацию тренеров с информацией о тренировках
            var trainings = from c in coaches
                            join t in pagedTrainings.Entities on c.Id equals t.TrainerId
                            select new TrainingUserResponse
                            {
                                Id = t.Id,
                                Name = t.Name,
                                Description = t.Description,
                                DateTime = t.DateTime,
                                Duration = t.Duration,
                                TrainerName = c.UserName,
                                FitnessClubName = t.FitnessClubName,
                                AreaName = t.AreaName,
                                TrainerNotes = t.TrainerNotes,
                                Points = t.Points,
                            };

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedTrainings.Pagination));
            return Ok(trainings);
        }

        [Authorize(Roles = nameof(Priviliges.Coach))]
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> AddTrainerNotes(Guid id, TrainingTrainerNotesRequest request)
        {
            var dto = _mapper.Map<TrainingTrainerNotesDto>(request);
            dto.TrainerId = UserId;

            await _service.AddTrainerNotes(id, dto);
            return NoContent();
        }

        [Authorize(Roles = nameof(Priviliges.User))]
        [HttpPost("[action]")]
        public async Task<IActionResult> AddTraining(TrainingCreateRequest request)
        {
            var trainingDto = _mapper.Map<TrainingCreateDto>(request);
            trainingDto.UserId = UserId;

            var id = await _service.AddTraining(trainingDto);

            return Ok(id.ToString());
        }

        [Authorize(Roles = nameof(Priviliges.User))]
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Cancel(Guid id)
        {
            await _service.Cancel(id, UserId);

            // ToDo: отправить оповещение тренеру, менеджеру об отмене тренировки

            return NoContent();
        }
    }
}
