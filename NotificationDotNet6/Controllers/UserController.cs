using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NotificationDotNet6.Domain.Commands.User;
using NotificationDotNet6.Domain.Entities;
using NotificationDotNet6.Domain.Services;

namespace NotificationDotNet6.Controllers;

public class UserController : Controller
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult>  Index()
    {
        var result = await _userService.GetAll();
        return View(result.Data as List<User>);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(UserCreateCommand command)
    {
        var result = await _userService.Handle(command);

        return RedirectToAction("Index");
    }
}