using System.ComponentModel.DataAnnotations;

namespace PinchOfPepper.Models
{
    public class User
    {
        [Key]
        public int id { get; set; }
        [Required]
        [Range(0, 30)]
        public string Username { get; set; }

        [Required]
        [Range(0, 16)]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public User()
        {
            //empty constructor
        }

        public User(int id, string username, string password, string email, string firstname, string lastname)
        {
            this.id = id;
            this.Username = username;
            this.Password = password;
            this.Email = email;
            this.FirstName = firstname;
            this.LastName = lastname;
        }
    }
}
