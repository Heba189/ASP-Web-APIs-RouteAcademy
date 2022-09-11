namespace Talabat.DAL.Entities.Order_Aggregate
{
    public class ProductItemOrdered
    {
        public ProductItemOrdered(int productId, string productName, string pictureUrl)
        {
            ProductId = productId;
            ProductName = productName;
            PictureUrl = pictureUrl;
        }
        public ProductItemOrdered()
        {

        }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string PictureUrl { get; set; }
    }
}