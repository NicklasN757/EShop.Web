namespace EShop.Api.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImgUrl { get; set; }
        public bool InStock { get; set; }
        public int TotalStock { get; set; }
        public bool IsDeleted { get; set; }
    }
}