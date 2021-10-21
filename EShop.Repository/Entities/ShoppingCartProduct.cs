using System.ComponentModel.DataAnnotations;

namespace EShop.Repository.Entities
{
    public class ShoppingCartProduct
    {
        [Required]
        public int ShoppingCartProductId { get; set; }

        //Foreign keys
        [Required]
        public int FK_ShoppingCart { get; set; }
        [Required]
        public int FK_Product { get; set; }

        //Navigations Properties
        public Product Product { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
    }
}