using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HW2.Models;
using HW2.DAL.Abstract;
using HW2.ViewModels;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HW2.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private IShowRepository _showRepo;
    private IPeopleRepository _peopleRepo;
    private IGenreRepository _genreRepo;

    public HomeController(ILogger<HomeController> logger, IShowRepository showRepo, IPeopleRepository peopleRepo, IGenreRepository genreRepository)
    {
        _logger = logger;
        _showRepo = showRepo;
        _peopleRepo = peopleRepo;
        _genreRepo = genreRepository;
    }
    public IActionResult Index()
    {
        StatsVM statsVM = new StatsVM(_showRepo, _peopleRepo, _genreRepo);
        return View(statsVM);
    }

    [HttpPost]
    public IActionResult Rating(StatsVM tempVM)
    {
        StatsVM statsVM = new StatsVM(_showRepo, _peopleRepo, _genreRepo);
        statsVM.genreChoice = tempVM.genreChoice;
        if(tempVM.pickedType == 0)
        {
            statsVM.pickedType = 2;
        }
        else
        {
            statsVM.pickedType = tempVM.pickedType;
        }
        statsVM.highest10ShowsInGenreStrings = _showRepo.HighestRatedShowInGenre10StringList(statsVM.genreChoice, statsVM.pickedType);
        statsVM.highest10ShowsList = _showRepo.HighestRatedShowInGenre10Lists(statsVM.highest10ShowsInGenreStrings);
        return View(statsVM);
    }

    public IActionResult Stats()
    {
        //Could make blank VM and then call the methods from the _repos and assignment them into the blank VM
        StatsVM statsVM = new StatsVM(_showRepo, _peopleRepo, _genreRepo);
        return View(statsVM);
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
