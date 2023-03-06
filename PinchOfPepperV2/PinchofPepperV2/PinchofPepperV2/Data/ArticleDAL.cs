using PinchofPepperV2.Interfaces;
using PinchofPepperV2.Models;
using System;

namespace PinchofPepperV2.Data
{
    public class ArticleDAL : IArticleAccessLayer
    {
        private ApplicationDbContext db;
        public ArticleDAL(ApplicationDbContext indb)
        {
            db = indb;
        }
        public void AddArticle(Article article)
        {
            db.Articles.Add(article);
            db.SaveChanges();
        }

        public void EditArticle(Article article)
        {
            db.Articles.Update(article);
            db.SaveChanges();
        }
        
        public Article GetArticle(int? id)
        {
            return db.Articles.Where(a => a.Id == id).FirstOrDefault();
        }

        public IEnumerable<Article> GetArticles()
        {
            return db.Articles.ToList();
        }

        public void RemoveArticle(int? id)
        {
            Article foundArt = GetArticle(id);
            db.Articles.Remove(foundArt);
            db.SaveChanges();
        }

        public IEnumerable<Article> FilterArticles(string tags)
        {
            throw new NotImplementedException();
        }

        public string GetUserFirstName(string userId)
        {
            var dbUsers = db.ApplicationUsers.Select(user => new { user.FirstName }).ToList();
            return dbUsers.First().FirstName;
        }
        public string GetUserLastName(string userId)
        {
            var dbUsers = db.ApplicationUsers.Select(user => new { user.LastName }).ToList();
            return dbUsers.First().LastName;
        }
        public string GetUserName(string userId)
        {
            var dbUsers = db.ApplicationUsers.Select(user => new { user.Name }).ToList();
            return dbUsers.First().Name;
        }

        public ApplicationUser GetUser(string? id)
        {
            return db.ApplicationUsers.Where(a => a.Id == id).FirstOrDefault();
        }


        //comments
        public void AddComment(CommentModel Comment)
        {
            db.Add(Comment);
            db.SaveChanges();
        }

        public void RemoveComment(int? id)
        {
            CommentModel comment = GetComment(id);
            db.Comments.Remove(comment);
            db.SaveChanges();
        }

        public void EditComment(CommentModel Comment)
        {
            db.Comments.Update(Comment);
            db.SaveChanges();
        }

        public CommentModel GetComment(int? id)
        {
            return db.Comments.Where(c => c.Id == id).FirstOrDefault();
        }

        public IEnumerable<CommentModel> GetComments()
        {
            return db.Comments.ToList();
        }
        public IEnumerable<CommentModel> GetPostComments(int? id)
        {
            return GetComments().Where(c => c.ArticleId == id).ToList();
        }
    }
}
