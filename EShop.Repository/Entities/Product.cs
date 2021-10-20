using System.Collections.Generic;
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
        public int TotalStock { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        //Foreign keys

        //Navigations Properties
        public PriceOffer PriceOffer { get; set; }
        public List<Order> Orders { get; set; }
        public List<OrderProduct> OrderProducts { get; set; }
        public List<ShoppingCartProduct> ShoppingCartProducts { get; set; }
    }
}