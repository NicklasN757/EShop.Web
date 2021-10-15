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

        //Foreign keys

        //Navigations Properties
        public ShoppingCartDTO ShoppingCart { get; set; }
        public PriceOfferDTO PriceOffer { get; set; }
    }
}