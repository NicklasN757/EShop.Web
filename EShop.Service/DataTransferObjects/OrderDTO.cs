using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Service.DataTransferObjects
{
    public class OrderDTO
    {
        public int OrderId { get; set; }

        public DateTime OrderDate { get; set; }

        //Foreign keys
        public int FK_ShooppingCartId { get; set; }
        public int FK_UserInformation { get; set; }

        //Navigations Properties
        public ShoppingCartDTO ShoppingCart { get; set; }
        public UserInformationDTO UserInformation { get; set; }
    }
}