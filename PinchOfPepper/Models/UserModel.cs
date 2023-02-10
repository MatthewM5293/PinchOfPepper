namespace PinchOfPepper.Models
{
    public class UserModel
    {
        public int id { get; set; }

        private string Username { get; set; }

        private string Password { get; set; }

        private string Email { get; set; }

        private string FirstName { get; set; }

        private string LastName { get; set; }

        public UserModel()
        {
            //empty constructor
        }
        public UserModel(int id, string username, string password, string email, string firstname, string lastname)
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
