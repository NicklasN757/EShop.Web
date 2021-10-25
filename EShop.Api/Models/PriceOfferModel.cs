using System;

namespace EShop.Api.Models
{
    public class PriceOfferModel
    {
        public int ProductId { get; set; }
        public double NewPrice { get; set; }
        public string OfferReason { get; set; }
        public DateTime DateStarted { get; set; }
        public DateTime DateEnding { get; set; }
    }
}