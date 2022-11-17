using System;
using NotificationDotNet6.Domain.Abstracts;

namespace NotificationDotNet6.Domain.Entities;

public record Notification : Entity
{
    // Constructor
    public Notification()
	{
	}

    public Notification(Guid fromUserId,
        Guid toUserId,
        string header,
        string body,
        bool isRead,
        string url)
    {
        FromUserId = fromUserId;
        ToUserId = toUserId;
        Header = header;
        Body = body;
        IsRead = isRead;
        Url = url;
    }

    
    // Porperties
	public string Header { get; private set; }

	public string Body { get; private set; }

	public bool IsRead { get; private set; }

	public string Url { get; private set; }

    // Relationship
    public Guid FromUserId { get; private set; }
    public Guid ToUserId { get; private set; }
    public virtual User User { get; private set; }
}