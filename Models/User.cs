namespace SmartMeets.Models
{
    public partial class User
    {
        public User(int UserID, string FirstName, string LastName, string Password)
        {

        }
        [Required]
        public int UserID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Password { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
