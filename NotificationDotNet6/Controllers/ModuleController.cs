﻿using Microsoft.AspNetCore.Mvc;

namespace NotificationDotNet6.Controllers;

public class ModuleController : Controller
{
    public IActionResult Module1()
    {
        return View();
    }

    public IActionResult Module2()
    {
        return View();
    }

    public IActionResult Module3()
    {
        return View();
    }
}