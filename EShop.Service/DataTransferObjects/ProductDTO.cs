using System.Collections.Generic;

namespace EShop.Service.DataTransferObjects
{
    public class ProductDTO
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public string ImgUrl { get; set; }

        public bool InStock { get; set; }

        public int Stock { get; set; }

        //Navigations Properties
        public PriceOfferDTO PriceOffer { get; set; }
        public List<OrderProductDTO> OrderProducts { get; set; }
        public List<ShoppingCartProductDTO> ShoppingCartProducts { get; set; }
    }
}