using NotificationDotNet6.Domain.Commands;
using NotificationDotNet6.Domain.Commands.Notification;

namespace NotificationDotNet6.Domain.Services;

public interface INotificationService : IService<NotificationCreateCommand>
    , IService<NotificationGetUserIdUnreadCommand>
{
    Task<GenericCommandResult> GetAll();
}