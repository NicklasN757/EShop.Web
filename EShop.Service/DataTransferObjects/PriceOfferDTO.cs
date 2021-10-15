using System;

namespace EShop.Service.DataTransferObjects
{
    public class PriceOfferDTO
    {
        public int ProductId { get; set; }

        public double NewPrice { get; set; }

        public string OfferReason { get; set; }

        public DateTime DateStarted { get; set; }

        public DateTime DateEnding { get; set; }

        //Navigations Properties
        public ProductDTO Product { get; set; }
    }
}