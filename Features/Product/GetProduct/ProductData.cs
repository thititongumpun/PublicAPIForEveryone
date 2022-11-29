using Bogus;

namespace ToyShopAPI.Features.Product.GetProduct;

public static class ProductData
{
  public static Task<Product> GetProduct(string productId)
  {
    var testProducts = new Faker<Product>()
      .RuleFor(c => c.ProductId, f => int.Parse(productId))
      .RuleFor(c => c.Item, f => f.Commerce.ProductName())
      .RuleFor(c => c.Quantity, f => f.Random.Number(1, 5))
      .RuleFor(c => c.Price, f => f.Commerce.Price())
      .RuleFor(c => c.Description, f => f.Commerce.ProductAdjective())
      .RuleFor(c => c.ImageUrl, (f, i) => f.Image.LoremFlickrUrl(480, 480, i.Item, false, true));

    return Task.Run(() => testProducts.Generate());
  }
}
