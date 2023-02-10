using System.ComponentModel.DataAnnotations;

namespace PinchOfPepper.Models
{
    public class Article
    {
        [Key]
        private int Id { get; set; }
        [Required]
        private string Title { get; set; }
        [Required]
        private string articleText { get; set; }
        [Required]
        private string authorName { get; set; }
        [Required]
        private DateTime date { get; set; }
        [Required]
        private string thumbnail { get; set; }
        private string? image1 { get; set; }
        private string? image2 { get; set; }

        public Article()
        {
        }

        public Article(string title, string articleText, string authorName, DateTime date, string thumbnail, string? image1, string? image2)
        {
            Title = title;
            this.articleText = articleText;
            this.authorName = authorName;
            this.date = date;
            this.thumbnail = thumbnail;
            this.image1 = image1;
            this.image2 = image2;
        }
    }
}
