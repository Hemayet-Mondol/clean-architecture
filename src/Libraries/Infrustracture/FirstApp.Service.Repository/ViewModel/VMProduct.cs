using FirstApp.Shared.Common;

namespace FirstApp.Service.Repository.ViewModel;

public class VMProduct : IVM
{
    public int Id { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public string ProductDescription { get; set; } = string.Empty;
    public string ProductCategory { get; set; } = string.Empty;
    public double ProductPrice { get; set; }
}
