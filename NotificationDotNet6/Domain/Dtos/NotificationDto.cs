using System;
namespace NotificationDotNet6.Domain.Dtos;

public record NotificationDto
{
    public Guid Id { get; set; }

    public Guid FromUserId { get; set; }

    public Guid ToUserId { get; set; }

    public string Header { get; set; } = "";

    public string Body { get; set; } = "";

    public bool IsRead { get; set; } = false;

    public string Url { get; set; } = "";

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public string Message { get; set; } = "";

    public string CreatedDateSt => this.CreatedDate.ToString("dd-MMM-yyyy HH:mm:ss");

    public string IsReadSt => this.IsRead ? "YES" : "NO";

    public string FromUserName { get; set; } = "";

    public string ToUserName { get; set; } = "";
}