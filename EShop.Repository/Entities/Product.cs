using System.ComponentModel.DataAnnotations;

namespace EShop.Repository.Entities
{
    public class Product
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public double Price { get; set; }

        public string ImgUrl { get; set; }

        [Required]
        public bool InStock { get; set; }

        [Required]
        public int Stock { get; set; }

        //Foreign keys

        //Navigations Properties
        public ShoppingCart ShoppingCart { get; set; }
        public PriceOffer PriceOffer { get; set; }
    }
}