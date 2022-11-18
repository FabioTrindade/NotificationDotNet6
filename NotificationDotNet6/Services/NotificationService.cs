using NotificationDotNet6.Domain.Commands;
using NotificationDotNet6.Domain.Commands.Notification;
using NotificationDotNet6.Domain.Entities;
using NotificationDotNet6.Domain.Repositories;
using NotificationDotNet6.Domain.Services;

namespace NotificationDotNet6.Services;

public class NotificationService : INotificationService
{
	private readonly INotificationRepository _notificationRepository;

    public NotificationService(INotificationRepository notificationRepository)
    {
        _notificationRepository = notificationRepository;
    }

    public async Task<GenericCommandResult> Handle(NotificationCreateCommand command)
    {
        var notification = new Notification(command.FromUserId, command.ToUserId, command.Header, command.Body, command.Url);
        var result = await _notificationRepository.Create(notification);

        return new GenericCommandResult(true, "", result);
    }

    public async Task<GenericCommandResult> Handle(NotificationGetUserIdUnreadCommand command)
    {
        var result = await _notificationRepository.GetAll(w => w.ToUserId == command.UserId && w.IsRead == command.Unread);

        return new GenericCommandResult(true, "", result);
    }

    public async Task<GenericCommandResult> GetAll()
    {
        var result = await _notificationRepository.GetAll();

        return new GenericCommandResult(true, "", result);
    }
}