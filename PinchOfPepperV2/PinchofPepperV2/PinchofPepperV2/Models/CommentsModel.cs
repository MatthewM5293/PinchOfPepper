using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PinchofPepperV2.Models
{
    public class CommentModel
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ArticleID")]
        public int ArticleId { get; set; }

        [ForeignKey("UserID")]
        public string UserID { get; set; }

        public string Username { get; set; }

        public DateTime CommentDate { get; set; }

        public DateTime? EditDate { get; set; }

        public string CommentText { get; set; }

        public CommentModel() { }
    }
}
