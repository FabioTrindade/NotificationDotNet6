using Microsoft.AspNetCore.Mvc;
using NotificationDotNet6.Domain.Commands.Notification;
using NotificationDotNet6.Domain.Services;

namespace NotificationDotNet6.Controllers;

public class NotificationController : Controller
{
    private readonly INotificationService _notificationService;

    public NotificationController(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }


    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> Getall()
    {
        var result = await _notificationService.GetAll();
        return View(result.Data);
    }

    [HttpGet]
    public async Task<JsonResult> GetNotifications()
    {
        var request = new NotificationGetUserIdUnreadCommand { Unread = true };
        var result = await _notificationService.Handle(request);

        return Json(result.Data);
    }
}