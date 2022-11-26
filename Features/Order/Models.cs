namespace ToyShopAPI.Features.Order;

public class Products
{
  public int ProductId { get; set; }
  public string Item { get; set; }
  public string Price { get; set; }
  public int Quantity { get; set; }
  public string Description { get; set; }
  public string ImageUrl { get; set; }
}

public class User
{
  public int Id { get; set; }
  public string Email { get; set; }
  public string Username { get; set; }
  public string FirstName { get; set; }
  public string LastName { get; set; }
  public List<Products> Products { get; set; }
}