using System.ComponentModel.DataAnnotations;

namespace PinchOfPepper.Models
{
    public class Article
    {
        [Key]
        private int Id { get; set; }
        [Required]
        private string title { get; set; }
        [Required]
        private string description { get; set; }
        [Required]
        private string articleText { get; set; }
        [Required]
        private string authorName { get; set; }
        [Required]
        private DateTime date { get; set; }
        [Required]
        private string thumbnail { get; set; }
        [Required]
        private string tag { get; set; }
        private string? image1 { get; set; }
        private string? image2 { get; set; }

        public Article()
        {
        }

        public Article(string title, string description, string articleText, string authorName, DateTime date, string thumbnail, string tag, string? image1, string? image2)
        {
            this.title = title;
            this.description = description;
            this.articleText = articleText;
            this.authorName = authorName;
            this.date = date;
            this.thumbnail = thumbnail;
            this.tag = tag;
            this.image1 = image1;
            this.image2 = image2;
        }
    }
}
