namespace Backend.Models
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }
        public Profile Profile { get; set; }
    }
    public class Profile
    {
        public string Address { get; set; }
        public string Phone { get; set; }
    }

}
