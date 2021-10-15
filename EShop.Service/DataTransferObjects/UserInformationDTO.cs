using System.Collections.Generic;

namespace EShop.Service.DataTransferObjects
{
    public class UserInformationDTO
    {
        public int UserId { get; set; }

        public string FullName { get; set; }

        public string City { get; set; }

        public string Adress { get; set; }

        public string EMail { get; set; }

        //Navigations Properties
        public UserDTO User { get; set; }
        public List<OrderDTO> Orders { get; set; }
    }
}