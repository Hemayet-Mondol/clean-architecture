using FirstApp.Shared.Common;

namespace FirstApp.Model
{
    public class Product:BaseEntity,IEntity
    {
        public string ProductName { get; set; }=string.Empty;
        public string ProductDescription { get; set; } = string.Empty;
        public string ProductCategory { get; set; }=string.Empty;
        public double ProductPrice { get; set; }
    }
}
