using Microsoft.AspNetCore.Mvc;
using NotificationDotNet6.Domain.Commands.Notification;
using NotificationDotNet6.Domain.Entities;
using NotificationDotNet6.Domain.Services;

namespace NotificationDotNet6.Controllers;

public class NotificationController : Controller
{
    private readonly INotificationService _notificationService;

    public NotificationController(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var result = await _notificationService.GetAll();
        return View(result.Data as List<Notification>);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(NotificationCreateCommand command)
    {
        var result = await _notificationService.Handle(command);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public ActionResult AllNotifications()
    {
        return View();
    }

    [HttpGet]
    public async Task<JsonResult> GetNotifications()
    {
        var request = new NotificationGetUserIdUnreadCommand { UserId = new Guid("3542838E-226D-4C34-A7F4-8E7EC3EB4A18"), Unread = false };
        var result = await _notificationService.Handle(request);

        return Json(result.Data);
    }

    [HttpGet]
    public async Task<JsonResult> GetAllNotifications()
    {
        var request = new NotificationGetUserIdUnreadCommand { UserId = new Guid("3542838E-226D-4C34-A7F4-8E7EC3EB4A18"), Unread = false };
        var result = await _notificationService.Handle(request);

        return Json(result.Data);
    }
}