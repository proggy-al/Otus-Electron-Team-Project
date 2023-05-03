using AutoMapper;
using GMS.Common.Commands;
using MassTransit;

namespace GMS.Communication.WebHost.Consumers
{
    public class AddTrainingNotificationConsumer : IConsumer<AddTrainingNotificationCmd>
    {
        private readonly IMapper _mapper;

        public AddTrainingNotificationConsumer(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task Consume(ConsumeContext<AddTrainingNotificationCmd> context)
        {
            var trainingNotification = context.Message;

            // ToDo: дальнейшая логика
        }
    }
}
