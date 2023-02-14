using System.ComponentModel.DataAnnotations;

namespace PinchofPepperV2.Models
{
    public class Article
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(0, 20)]
        public string Title { get; set; }

        [Required]
        [Range(0, 100)]
        public string Description { get; set; }

        [Required]
        [Range(0, 2500)]
        public string ArticleText { get; set; }

        [Required]
        [Range(0, 30)]
        public string AuthorName { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public DateTime? EditDate { get; set; }

        [Required]
        public string Thumbnail { get; set; }

        [Required]
        public string Tag { get; set; }
        public string? Image1 { get; set; }
        public string? Image2 { get; set; }

        public Article()
        {
        }

        public Article(string title, string description, string articleText, string authorName, DateTime date, DateTime editdate, string thumbnail, string tag, string? image1, string? image2)
        {
            this.Title = title;
            this.Description = description;
            this.ArticleText = articleText;
            this.AuthorName = authorName;
            this.Date = date;
            this.EditDate = editdate;
            this.Thumbnail = thumbnail;
            this.Tag = tag;
            this.Image1 = image1;
            this.Image2 = image2;
        }
    }
}
