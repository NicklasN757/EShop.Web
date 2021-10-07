using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Repository.Entities
{
    public class Order
    {
        [Required]
        public int OrderId { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        //Foreign keys
        public int FK_ShooppingCartId { get; set; }
        public int FK_UserInformation { get; set; }

        //Navigations Properties
        public ShoppingCart ShoppingCart { get; set; }
        public UserInformation UserInformation { get; set; }
    }
}