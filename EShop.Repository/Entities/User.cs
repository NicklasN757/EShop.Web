using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EShop.Repository.Entities
{
    public class User
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public int Pin { get; set; }

        [Required]
        public bool IsAdmin { get; set; }

        //Foreign keys

        //Navigations Properties
        public UserInformation UserInformation { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public List<Order> Orders { get; set; }
    }
}