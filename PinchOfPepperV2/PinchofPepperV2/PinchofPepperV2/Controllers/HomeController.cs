using Microsoft.AspNetCore.Mvc;
using PinchofPepperV2.Models;
using System.Diagnostics;
using PinchofPepperV2.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Net.Mail;
using System.Net;

namespace PinchofPepperV2.Controllers
{
    [Authorize]
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
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier).ToString();
            if (userId == "" || userId == null)
            {
                
            }
            else 
            {
                string test = dal.GetUserName(userId);
                LocalUsername.SetLocalUsername(test);
            }


            return View(dal.GetArticles());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ShowArticle(int Id)
        {
            return View(dal.GetArticle(Id));
        }

        [Authorize]
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
                a.UserID = User.FindFirstValue(ClaimTypes.NameIdentifier);

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

        //public void EmaelSender(string userEmail)
        //{
        //    var client = new SmtpClient("sandbox.smtp.mailtrap.io", 2525)
        //    {
        //        Credentials = new NetworkCredential("515c6d0a0cfb9d", "8dffeaabb6464b"),
        //        EnableSsl = true
        //    };
        //    client.Send("POP@pinchofpepper.com", userEmail, "Account Created!", "Congrats! Youve created an account on Pinch of Pepper");
        //    Console.WriteLine("Sent");
        //    //Console.ReadLine();

        //    //using (SmtpClient smtp = new SmtpClient())
        //    //{
        //    //    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
        //    //    smtp.UseDefaultCredentials = false;
        //    //    smtp.EnableSsl = true;
        //    //    smtp.Host = "smtp.gmail.com";
        //    //    smtp.Port = 465;
        //    //    smtp.Credentials = new NetworkCredential("hattyhattington2003@gmail.com", "DanPaladin6012!");
        //    //    smtp.Timeout = 20000;

        //    //    smtp.Send("rsorensen@student.neumont.edu", "averystephens0@gmail.com", "Hello world!", "testbody123");
        //    //    Console.WriteLine("Sent");
        //    //}

        //    //return RedirectToAction("Index", "Home");
        //}
    }
}