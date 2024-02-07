using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HW1.Models;
using HW1.ViewModels;
using System.Text.RegularExpressions;

namespace HW1.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    public IActionResult Index(TeamsVM vm)
    {
        if(ModelState.IsValid)
        {
            ViewBag.IsValid = true;
        }
        else
        {
            ViewBag.IsValid = false;
        }
        return View(vm);
    }

    [HttpPost]
    public IActionResult Teams(TeamsVM vm)
    {
        string allowedChars = @"^[a-zA-Z,.-_']*\s[a-zA-Z,.-_']*";
        var check = true;
        if(vm.MemberNames == null)
        {
            return RedirectToAction("Index");
        }
        else 
        {
            check = Regex.IsMatch(vm.MemberNames, allowedChars);
            if(check == false)
            return RedirectToAction("Index");
        }
        return View(vm);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
