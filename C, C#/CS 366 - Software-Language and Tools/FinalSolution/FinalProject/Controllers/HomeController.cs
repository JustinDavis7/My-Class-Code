using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FinalProject.Models;

namespace FinalProject.Controllers
{
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

        public IActionResult Itinerary()
        {
            return View();
        }

        public IActionResult RsvpResponse()
        {
            return View();
        }

        public IActionResult FoodMenu()
        {
            return View();
        }

        public ViewResult MenuList() {
            return View(MenuRepository.Responses);
        }

        [HttpGet]
        public ViewResult RsvpForm() {
            return View();
        }

        [HttpPost]
        public ViewResult RsvpForm(Responses guestResponse) {
            if (ModelState.IsValid){
                Repository.AddResponse(guestResponse);
                return View("RsvpResponse", guestResponse);
            } else {
                return View();
            }
        }

        [HttpGet]
        public ViewResult Menu() {
            return View();
        }

        [HttpPost]
        public ViewResult Menu(MenuResponses MenuResponse) {
            if (ModelState.IsValid){
                MenuRepository.AddResponse(MenuResponse);
                return View("MenuResponse", MenuResponse);
            } else {
                return View();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
