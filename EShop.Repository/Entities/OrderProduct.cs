using System.ComponentModel.DataAnnotations;

namespace EShop.Repository.Entities
{
    public class OrderProduct
    {
        [Required]
        public int OrderProductId { get; set; }

        //Foreign keys
        [Required]
        public int FK_Order { get; set; }
        [Required]
        public int FK_Product { get; set; }

        //Navigations Properties
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}