using NotificationDotNet6.Domain.Contracts;

namespace NotificationDotNet6.Domain.Commands.Notification;

public class NotificationCreateCommand : ICommand
{
    public string Header { get; set; }

    public string Body { get; set; }

    public string Url { get; set; }

    public Guid FromUserId { get; set; }

    public Guid ToUserId { get; set; }
}