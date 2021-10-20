using System;
using System.Collections.Generic;

namespace EShop.Service.DataTransferObjects
{
    public class OrderDTO
    {
        public int OrderId { get; set; }

        public DateTime OrderDate { get; set; }

        public double TotalOrderPrice { get; set; }

        //Foreign keys
        public int? FK_UserInformationId { get; set; }
        public int? FK_UserId { get; set; }

        //Navigations Properties
        public UserInformationDTO UserInformation { get; set; }
        public UserDTO User { get; set; }
        public List<OrderProductDTO> OrderProducts { get; set; }
    }
}