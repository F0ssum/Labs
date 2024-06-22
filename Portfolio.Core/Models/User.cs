namespace Portfolio.Core.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public ICollection<Project> Projects { get; set; }
        //public ICollection<Comment> Comments { get; set; }

        public User()
        {
            Projects = new List<Project>();
            //Comments = new List<Comment>();
        }
    }
}
