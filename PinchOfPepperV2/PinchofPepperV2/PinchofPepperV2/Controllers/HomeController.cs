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
        private static string UserId;
        private static int? ArticleId;

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
                UserIdVerify();
                string test = dal.GetUserName(userId);
                LocalUsername.SetLocalUsername(test);
            }


            return View(dal.GetArticles());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize]
        public IActionResult ShowArticle(int Id)
        {
            UserIdVerify();

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
            a.AuthorName = dal.GetUserName(UserId);
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

        public IActionResult EasterEgg() 
        {
            return Redirect("https://www.youtube.com/watch?v=dQw4w9WgXcQ");
        }


        //article edit and delete
        [Authorize]
        [HttpGet]
        public IActionResult EditArticle(int? id)
        {
            if (id == null)
                return NotFound();

            Article foundArticle = dal.GetArticle(id);

            if (foundArticle == null) return NotFound();

            return View(foundArticle);
        }

        [HttpPost]
        public IActionResult EditArticle(Article a)
        {
            if (ModelState.IsValid)
            {
                a.UserID = User.FindFirstValue(ClaimTypes.NameIdentifier);
                dal.EditArticle(a);

                return RedirectToAction("Index", "Home", fragment: a.Id.ToString());
            }
            return View();

        }

        public IActionResult DeleteArticle(int? id)
        {
            if (dal.GetArticle(id) == null)
            {
                //validator
                ModelState.AddModelError("ArticleId", "Cannot find article to delete");
            }
            if (ModelState.IsValid)
            {
                //deletes comments of post
                //var temp = dal.GetPostComments(id);
                //foreach (var comment in temp)
                //{
                //    DeleteComment(comment.Id);
                //}

                dal.RemoveArticle(id);
            }
            else
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        public void UserIdVerify()
        {
            UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.UserId = UserId;
        }
    }
}