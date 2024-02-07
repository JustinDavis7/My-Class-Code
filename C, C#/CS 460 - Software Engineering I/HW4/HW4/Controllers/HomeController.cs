using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HW4.Models;
using HW4.DAL.Abstract;
using HW4.ViewModels;

namespace HW4.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IPersonRepository _personRepo;
    private readonly IToDoItemRepository _toDoRepo;

    public HomeController(ILogger<HomeController> logger, IPersonRepository personRepo, IToDoItemRepository toDoRepo)
    {
        _logger = logger;
        _personRepo = personRepo;
        _toDoRepo = toDoRepo;
    }

    public IActionResult Index()
    {
        return View();
    }

    // GET: /user/first%20last
    // Sample link for my user: /user/Justin Davis
    public IActionResult User(string? id)
    {
        //var name = this.RouteData.Values.Values.Last().ToString().Split(" "); //This is another way of doing this without the id passed in.
        if (id == null)
        {
            return NotFound();
        }
        var user = _personRepo.GetPersonInfo(id);
        PersonToDoVM userVM = new PersonToDoVM();
        userVM._user = user;
        return View(userVM);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(PersonToDoVM item)
    {
        if (ModelState.IsValid)
        {
            var temp = item._item;
            temp.Person = item._user;
            temp.PersonId = item._user.Id;
            // We have a model that passes any validation we've specified
            try
            { 
                _toDoRepo.AddOrUpdate(temp);
            }
            catch (DbUpdateConcurrencyException e)
            {
                // Shouldn't happen during a create, but it since it could be thrown
                // we must handle it
                ViewBag.Message = "A concurrency error occurred while trying to create the item.  Please try again.";
                return View(item);
            }
            catch (DbUpdateException e)
            {
                ViewBag.Message = "An unknown database error occurred while trying to create the item.  Please try again.";
                return View(item);
            }
            var url = string.Format("user/{0} {1}",temp.Person.FirstName, temp.Person.LastName);
            return Redirect(url);
        }
        else
        {
            ViewBag.Message = "The ModelState isn't valid";
            return View(item);
        }
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
