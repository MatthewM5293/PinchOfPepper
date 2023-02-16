using Microsoft.AspNetCore.Mvc;
using PinchofPepperV2.Models;
using System.Diagnostics;
using PinchofPepperV2.Interfaces;

namespace PinchofPepperV2.Controllers
{
    public class HomeController : Controller
    {
        //private static List<Article> Articlelist = new List<Article>
        //{
        //    new Article("T", "test", "Joe Mama", "J Moe", DateTime.Now, null, "https://img.buzzfeed.com/buzzfeed-static/static/2018-10/2/18/campaign_images/buzzfeed-prod-web-06/15-of-the-weirdest-and-darkest-stock-photos-that--2-21628-1538520564-0_dblbig.jpg?resize=1200:*", "tag", null, null)
        //};

        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        IArticleAccessLayer dal;

        public HomeController(IArticleAccessLayer edal)
        {
            dal = edal;
        }

        public IActionResult Index()
        {
            return View(/*Articlelist*/);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CreateArticle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateArticle(Article a)
        {
            if(ModelState.IsValid)
            {
                dal.AddArticle(a);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}