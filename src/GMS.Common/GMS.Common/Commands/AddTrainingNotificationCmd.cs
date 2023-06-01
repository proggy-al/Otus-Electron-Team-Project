namespace GMS.Common.Commands;

public record AddTrainingNotificationCmd
(
    Guid TrainingId,
    Guid UserId,
    string TrainingName,
    DateTime DateTime,
    string UserName,    
    string Email
);
