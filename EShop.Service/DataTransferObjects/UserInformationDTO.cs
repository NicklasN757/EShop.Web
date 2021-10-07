using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Service.DataTransferObjects
{
    public class UserInformationDTO
    {
        public int UserId { get; set; }

        public string FullName { get; set; }

        public string City { get; set; }

        public string Adress { get; set; }

        public string EMail { get; set; }

        //Foreign keys

        //Navigations Properties
        public UserDTO User { get; set; }
        public List<OrderDTO> Orders { get; set; }
    }
}