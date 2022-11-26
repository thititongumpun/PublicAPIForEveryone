using Bogus;

namespace ToyShopAPI.Features.Product;

public class Endpoint : EndpointWithoutRequest
{
  public override void Configure()
  {
    Post("/products");
    Version(1);
    AllowAnonymous();
  }

  public override async Task HandleAsync(CancellationToken ct)
  {
    int productIds = 1;
    var testProducts = new Faker<Product>()
      .RuleFor(c => c.ProductId, f => productIds++)
      .RuleFor(c => c.Item, f => f.Commerce.ProductName())
      .RuleFor(c => c.Quantity, f => f.Random.Number(1, 5))
      .RuleFor(c => c.Price, f => f.Commerce.Price())
      .RuleFor(c => c.Description, f => f.Commerce.ProductAdjective())
      .RuleFor(c => c.ImageUrl, (f, i) => f.Image.LoremFlickrUrl(480, 480, i.Item, false, true));

    await SendAsync(new
    {
      Response = testProducts.Generate(20)
    }, cancellation: ct);
  }
}