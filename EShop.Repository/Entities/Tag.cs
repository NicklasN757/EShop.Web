using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EShop.Repository.Entities
{
    public class Tag
    {
        [Required]
        public int TagId { get; set; }
        [Required]
        public string TagName { get; set; }

        //Navigations Properties
        public List<ProductTag> ProductsTags { get; set; }
    }
}