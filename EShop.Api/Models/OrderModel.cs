using System;

namespace EShop.Api.Models
{
    public class OrderModel
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public double TotalOrderPrice { get; set; }
        public int FK_UserInformationId { get; set; }
        public int FK_UserId { get; set; }
    }
}