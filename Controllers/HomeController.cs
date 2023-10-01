using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using identity_oidc.Models;
using Microsoft.AspNetCore.Authorization;

namespace identity_oidc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [Authorize(Roles="SecurityAdmins,SuperAdmins")]
    public IActionResult Security()
    {
        return View();
    }

    [Authorize(Roles="SuperAdmins")]
    public IActionResult Administration()
    {
        return View();
    }

    public IActionResult AccessDenied()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
