namespace EShop.Service.DataTransferObjects
{
    public class ShoppingCartProductDTO
    {
        public int ShoppingCartProductId { get; set; }

        //Foreign keys
        public int FK_ShoppingCart { get; set; }
        public int FK_Product { get; set; }

        //Navigations Properties
        public ShoppingCartDTO ShoppingCart { get; set; }
        public ProductDTO Product { get; set; }
    }
}
