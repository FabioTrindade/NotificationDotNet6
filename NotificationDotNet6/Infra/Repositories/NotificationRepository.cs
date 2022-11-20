using System;
using System.Reflection.PortableExecutable;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using NotificationDotNet6.Domain.Dtos;
using NotificationDotNet6.Domain.Entities;
using NotificationDotNet6.Domain.Repositories;
using NotificationDotNet6.Infra.Contexts;

namespace NotificationDotNet6.Infra.Repositories;

public class NotificationRepository : EntityRepository<Notification>, INotificationRepository
{
    public NotificationRepository(NotificationDataContext context) : base(context)
    {
    }

    public async Task<List<NotificationDto>> GetAll(Guid toUserId, bool isRead)
    {
        var notifications = await _context.Notifications
                                    .Include("User")
                                    .Where(w => w.ToUserId == toUserId && w.IsRead == isRead)
                                    .Select(s => new NotificationDto
                                    {
                                        Id = s.Id,
                                        FromUserId = s.FromUserId,
                                        ToUserId = s.ToUserId,
                                        Header = s.Header,
                                        Body = s.Body,
                                        IsRead = s.IsRead,
                                        Url = s.Url,
                                        CreatedDate = s.CreatedAt,
                                        Message = "",
                                        FromUserName = s.User.Name,
                                        ToUserName = s.User.Name
                                    }).ToListAsync();

        return notifications;
    }
}