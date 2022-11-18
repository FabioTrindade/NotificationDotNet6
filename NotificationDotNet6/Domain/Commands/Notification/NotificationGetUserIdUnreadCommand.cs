using NotificationDotNet6.Domain.Contracts;

namespace NotificationDotNet6.Domain.Commands.Notification;

public class NotificationGetUserIdUnreadCommand : ICommand
{
	public Guid UserId { get; set; }

	public bool Unread { get; set; }
}