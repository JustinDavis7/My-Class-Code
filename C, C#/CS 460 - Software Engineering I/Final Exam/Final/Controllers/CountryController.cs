using Microsoft.AspNetCore.Mvc;
using Final.DAL;
using Final.Models;
using Final.ViewModels;

namespace Final.Controllers
{
    /*
     * Finish this controller to implement the Country page
     */

    public class CountryController : Controller
    {
        // **********************************************
        // Please use your implemented ICountryRepository
        // **********************************************
        private readonly ICountryRepository _countryRepository;

        public CountryController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }
    
        public IActionResult Index(string countryAbbreviation)
        {
            // **********************************************
            // Your implementation here.  Use the CountryPageVM viewmodel to return your results
            // **********************************************

            var country = _countryRepository.CountryExists(countryAbbreviation);
            var goalies = _countryRepository.GetPositionPlayers(countryAbbreviation, "Goalkeeper");
            var defenders = _countryRepository.GetPositionPlayers(countryAbbreviation, "Defender");
            var midfielders = _countryRepository.GetPositionPlayers(countryAbbreviation, "Midfielder");
            var forwards = _countryRepository.GetPositionPlayers(countryAbbreviation, "Forward");
            CountryPageVM countryVM = new CountryPageVM(country, goalies, defenders, midfielders, forwards);
            return View(countryVM);
        }
    }
}
