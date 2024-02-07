using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Final.Models;
using Final.DAL;

namespace Final.Controllers;

public class HomeController : Controller
{
    private readonly IRepository<Country> _countryRepository;

    public HomeController(IRepository<Country> countryRepository)
    {
        _countryRepository = countryRepository;
    }

    public IActionResult Index()
    {
        IEnumerable<Country> countryList = _countryRepository.GetAll();
        return View(countryList);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
