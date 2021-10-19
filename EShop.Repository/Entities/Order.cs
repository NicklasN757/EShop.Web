using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EShop.Repository.Entities
{
    public class Order
    {
        [Required]
        public int OrderId { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public int  TotalOrderPrice { get; set; }

        //Foreign keys
        public int? FK_UserInformationId { get; set; }
        public int? FK_UserId { get; set; }

        //Navigations Properties
        public UserInformation UserInformation { get; set; }
        public User User { get; set; }
        public List<OrderProduct> OrderProducts { get; set; }
    }
}