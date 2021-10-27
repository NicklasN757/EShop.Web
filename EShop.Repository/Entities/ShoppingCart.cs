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

        //Navigations Properties
        public List<ShoppingCartProduct> ShoppingCartProducts { get; set; }
        public User User { get; set; }
    }
}