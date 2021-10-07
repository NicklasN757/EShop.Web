using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EShop.Repository.Entities
{
    public class ShoppingCart
    {
        [Required]
        public int ShoppingCartId { get; set; }

        [Required]
        public double TotalPrice { get; set; }

        [Required]
        public bool IsFinished { get; set; }

        //Foreign keys
        public int FK_UserId { get; set; }
        public int FK_Product { get; set; }

        //Navigations Properties
        public List<Product> Products { get; set; }
        public User User { get; set; }
    }
}