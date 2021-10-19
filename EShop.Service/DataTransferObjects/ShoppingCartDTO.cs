using System.Collections.Generic;

namespace EShop.Service.DataTransferObjects
{
    public class ShoppingCartDTO
    {
        public int ShoppingCartId { get; set; }

        public double TotalPrice { get; set; }

        //Navigations Properties
        public UserDTO User { get; set; }
        public List<ShoppingCartProductDTO> ShoppingCartProducts { get; set; }
    }
}