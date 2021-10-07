using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Service.DataTransferObjects
{
    public class UserDTO
    {
        public int UserId { get; set; }

        public string Username { get; set; }

        public int Pin { get; set; }

        public bool IsAdmin { get; set; }

        //Foreign keys

        //Navigations Properties
        public UserInformationDTO UserInformation { get; set; }
        public List<ShoppingCartDTO> ShoppingCarts { get; set; }
    }
}