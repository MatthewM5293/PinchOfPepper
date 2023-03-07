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
    //[Authorize]
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

            if (Id == null) return NotFound();
            var temp = dal.GetArticles();

            //shows comments
            foreach (Article model in temp)
            {
                model.Comments = dal.GetPostComments(model.Id);
            }

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
                var RouteValues = new RouteValueDictionary {
                    { "id", a.Id }
                };
                return RedirectToAction("ShowArticle", "Home", routeValues: RouteValues);
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

        public IActionResult Filter(string tag)
        {
            return View("Index", dal.FilterArticles(tag));
        }

        //comments

        [Authorize]
        [HttpGet]
        public IActionResult AddComment(int? ArticleID)
        {
            ViewBag.ArticleID = ArticleID;
            //global variable
            ArticleId = ArticleID;
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddComment(CommentModel comment)
        {
            var id = ArticleId;

            var temp = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ApplicationUser foundUser = dal.GetUser(temp);
            Article foundArticle = dal.GetArticle(id);

            if (id == null || foundArticle == null || foundUser == null) return NotFound();

            if (ModelState.IsValid)
            {
                comment.ArticleId = foundArticle.Id;
                comment.UserID = foundUser.Id;

                comment.Username = foundUser.Name;

                dal.AddComment(comment);

                var RouteValues = new RouteValueDictionary {
                    { "id", foundArticle.Id }
                };



                return RedirectToAction("ShowArticle", "Home", routeValues: RouteValues, fragment: comment.Id.ToString());
            }

            return View();
        }

        [Authorize]
        [HttpGet]
        public IActionResult EditComment(int? id)
        {
            if (id == null)
                return NotFound();

            CommentModel foundComment = dal.GetComment(id);

            if (foundComment == null) return NotFound();

            return View(foundComment);
        }

        [HttpPost]
        public IActionResult EditComment(CommentModel c)
        {
            if (ModelState.IsValid)
            {
                dal.EditComment(c);

                var RouteValues = new RouteValueDictionary {
                    { "id", c.ArticleId }
                };

                return RedirectToAction("ShowArticle", "Home", routeValues: RouteValues, fragment: c.Id.ToString());
            }
            return View();

        }

        public IActionResult DeleteComment(int? id)
        {
            CommentModel foundComment;
            if (dal.GetComment(id) == null)
            {
                //validator
                ModelState.AddModelError("CommentId", "Cannot find comment to delete");
            }
            if (ModelState.IsValid)
            {
                foundComment = dal.GetComment(id);

                dal.RemoveComment(id);
            }
            else
            {
                return View();
            }

            var RouteValues = new RouteValueDictionary {
                    { "id", foundComment.ArticleId }
                };
            return RedirectToAction("ShowArticle", "Home", routeValues: RouteValues);
        }


        public void UserIdVerify()
        {
            UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.UserId = UserId;
        }
    }
}