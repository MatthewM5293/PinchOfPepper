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
    }
}
