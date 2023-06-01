using AutoMapper;
using GMS.Common.Commands;
using GMS.Communication.WebHost.Models;
using MassTransit;

namespace GMS.Communication.WebHost.Consumers
{
    public class AddTrainingNotificationConsumer : IConsumer<AddTrainingNotificationCmd>
    {
        private readonly IMapper _mapper;
        private readonly INotificatable _notifier;

        public AddTrainingNotificationConsumer(IMapper mapper, INotificatable notifier)
        {
            _mapper = mapper;
            _notifier = notifier;
        }

        public async Task Consume(ConsumeContext<AddTrainingNotificationCmd> context)
        {
            AddTrainingNotificationCmd trainingNotification = context.Message;
            await _notifier.AddNotificationAsync(_mapper.Map<TrainingNotification>(trainingNotification));
        }
    }
}
