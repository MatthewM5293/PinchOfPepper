using PinchofPepperV2.Models;

namespace PinchofPepperV2.Interfaces
{
    public interface IArticleAccessLayer
    {
        //articles
        IEnumerable<Article> GetArticles();

        void AddArticle(Article article);
        void RemoveArticle(int? id);
        void EditArticle(Article article);
        Article GetArticle(int? id);

        IEnumerable<Article> FilterArticles(string tags);

        //users
        public string GetUserFirstName(string userId);
        public string GetUserLastName(string userId);
        public string GetUserName(string userId);
        public ApplicationUser GetUser(string? id);


        //comments
        public void AddComment(CommentModel Comment);
        public void RemoveComment(int? id);
        public void EditComment(CommentModel Comment);
        public CommentModel GetComment(int? id);
        IEnumerable<CommentModel> GetComments();
        IEnumerable<CommentModel> GetPostComments(int? id);
    }
}
