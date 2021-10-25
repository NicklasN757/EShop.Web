namespace EShop.Api.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public int Pin { get; set; }
        public bool IsAdmin { get; set; }
    }
}