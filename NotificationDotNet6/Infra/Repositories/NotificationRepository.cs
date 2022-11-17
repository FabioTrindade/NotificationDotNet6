using NotificationDotNet6.Domain.Entities;
using NotificationDotNet6.Domain.Repositories;
using NotificationDotNet6.Infra.Contexts;

namespace NotificationDotNet6.Infra.Repositories;

public class NotificationRepository : EntityRepository<Notification>, INotificationRepository
{
    public NotificationRepository(NotificationDataContext context) : base(context)
    {
    }
}