namespace ToyShopAPI.Features.Product;

public class Product
{
  public int ProductId { get; set; }
  public string Item { get; set; }
  public string Price { get; set; }
  public int Quantity { get; set; }
  public string Description { get; set; }
  public string ImageUrl { get; set; }
}