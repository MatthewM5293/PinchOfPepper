using System.ComponentModel.DataAnnotations;

namespace PinchofPepperV2.Models
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

        public DateTime? EditDate { get; set; }

        [Required]
        public string Thumbnail { get; set; }

        [Required]
        public string Tag { get; set; }
        public string? Image1 { get; set; }
        public string? Image2 { get; set; }
        //[Required]
        public string? UserID { get; set; }
        public IEnumerable<CommentModel>? Comments { get; set; }

        public Article()
        {
        }
    }
}
