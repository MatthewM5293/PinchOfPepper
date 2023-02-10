using System.ComponentModel.DataAnnotations;

namespace PinchOfPepper.Models
{
    public class Article
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ArticleText { get; set; }
        [Required]
        public string AuthorName { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Thumbnail { get; set; }
        [Required]
        public string Tag { get; set; }
        public string? Image1 { get; set; }
        public string? Image2 { get; set; }

        public Article()
        {
        }

        public Article(string title, string description, string articleText, string authorName, DateTime date, string thumbnail, string tag, string? image1, string? image2)
        {
            this.Title = title;
            this.Description = description;
            this.ArticleText = articleText;
            this.AuthorName = authorName;
            this.Date = date;
            this.Thumbnail = thumbnail;
            this.Tag = tag;
            this.Image1 = image1;
            this.Image2 = image2;
        }
    }
}
