using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Service.DataTransferObjects
{
    public class ShoppingCartDTO
    {
        public int ShoppingCartId { get; set; }

        public double TotalPrice { get; set; }

        public bool IsFinished { get; set; }

        //Foreign keys
        public int FK_UserId { get; set; }
        public int FK_Product { get; set; }

        //Navigations Properties
        public List<ProductDTO> Products { get; set; }
        public UserDTO User { get; set; }
        public OrderDTO Order { get; set; }
    }
}