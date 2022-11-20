using NotificationDotNet6.Domain.Dtos;
using NotificationDotNet6.Domain.Entities;

namespace NotificationDotNet6.Domain.Repositories;

public interface INotificationRepository : IEntityRepository<Notification>
{
    public Task<List<NotificationDto>> GetAll(Guid toUserId, bool isRead);
}