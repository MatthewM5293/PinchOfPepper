namespace PinchOfPepper.Models
{
    public class User
    {
        public int id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

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
