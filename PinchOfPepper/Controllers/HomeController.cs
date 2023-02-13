using Microsoft.AspNetCore.Mvc;
using PinchOfPepper.Models;
using System.Diagnostics;

namespace PinchOfPepper.Controllers
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
            //hi
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateUser() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateUser(string email, string username, string password, string firstName, string lastName) 
        {
            //check if username/email already exists in database
            //check for valid password
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string username, string password) 
        {
            //check if username/email exists in database
            //check for valid password
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}