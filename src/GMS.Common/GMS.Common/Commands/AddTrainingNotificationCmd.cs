namespace GMS.Common.Commands;

public record AddTrainingNotificationCmd
(
    Guid TrainingId,
    string TrainingName,
    DateTime DateTime,
    string UserName,
    string Email
);
