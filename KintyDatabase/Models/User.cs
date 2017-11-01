namespace KintyDatabase.Models
{
    public class User
    {
        // Primary key
        public int UserId { get; set; }

        // Username
        public string Username { get; set; }

        // Email
        public string Email { get; set; }

        // Full name
        public string FullName { get; set; }
    }
}
