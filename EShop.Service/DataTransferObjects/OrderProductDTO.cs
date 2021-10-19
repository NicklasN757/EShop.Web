namespace EShop.Service.DataTransferObjects
{
    public class OrderProductDTO
    {
        public int OrderProductId { get; set; }

        //Foreign keys
        public int FK_Order { get; set; }
        public int FK_Product { get; set; }

        //Navigations Properties
        public OrderDTO Order { get; set; }
        public ProductDTO Product { get; set; }
    }
}
