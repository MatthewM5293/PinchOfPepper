using PinchofPepperV2.Models;

namespace PinchofPepperV2.Interfaces
{
    public interface IArticleAccessLayer
    {
        IEnumerable<Article> GetArticles();

        void AddArticle(Article article);
        void RemoveArticle(int? id);
        void EditArticle(Article article);
        Article GetArticle(int? id);

        IEnumerable<Article> FilterArticles(string tags);

        public string GetUserFirstName(string userId);
        public string GetUserLastName(string userId);
        public string GetUserName(string userId);
    }
}
