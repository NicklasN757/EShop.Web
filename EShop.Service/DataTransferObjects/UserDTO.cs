using System.Collections.Generic;

namespace EShop.Service.DataTransferObjects
{
    public class UserDTO
    {
        public int UserId { get; set; }

        public string Username { get; set; }

        public int Pin { get; set; }

        public bool IsAdmin { get; set; }

        //Navigations Properties
        public ShoppingCartDTO ShoppingCart { get; set; }
        public List<OrderDTO> Orders { get; set; }
        public UserInformationDTO UserInformation { get; set; }
    }
}