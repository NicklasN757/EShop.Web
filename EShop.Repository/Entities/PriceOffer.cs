using System;
using System.ComponentModel.DataAnnotations;

namespace EShop.Repository.Entities
{
    public class PriceOffer
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public double NewPrice { get; set; }
        [Required]
        public string OfferReason { get; set; }
        [Required]
        public DateTime DateStarted { get; set; }
        [Required]
        public DateTime DateEnding { get; set; }

        //Navigations Properties
        public Product Product { get; set; }
    }
}