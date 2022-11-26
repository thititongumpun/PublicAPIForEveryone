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
    var f = new Faker<Response>()
      .RuleFor(c => c.ProductId, f => productIds++)
      .RuleFor(c => c.Item, f => f.Commerce.Product())
      .RuleFor(c => c.Quantity, f => f.Random.Number(1, 5))
      .RuleFor(c => c.Price, f => f.Commerce.Price())
      .RuleFor(c => c.Description, f => f.Commerce.ProductAdjective());

    await SendAsync(new
    {
      Response = f.Generate(10)
    }, cancellation: ct);
  }
}