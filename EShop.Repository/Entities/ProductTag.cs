using System.ComponentModel.DataAnnotations;

namespace EShop.Repository.Entities
{
    public class ProductTag
    {
        [Required]
        public int ProductTagId { get; set; }

        //Foreign keys
        [Required]
        public int FK_Product { get; set; }
        [Required]
        public int FK_Tag { get; set; }

        //Navigations Properties
        public Tag Tag { get; set; }
        public Product Product { get; set; }
    }
}