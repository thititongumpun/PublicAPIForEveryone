using Bogus;

namespace ToyShopAPI.Features.Order;

public class Endpoint : EndpointWithoutRequest
{
  public override void Configure()
  {
    Get("/orders");
    Version(1);
    AllowAnonymous();
  }

  public override async Task HandleAsync(CancellationToken ct)
  {
    int productIds = 1;
    int userIds = 1;
    var testProducts = new Faker<Products>()
      .RuleFor(c => c.ProductId, f => productIds++)
      .RuleFor(c => c.Item, f => f.Commerce.ProductName())
      .RuleFor(c => c.Quantity, f => f.Random.Number(1, 5))
      .RuleFor(c => c.Price, f => f.Commerce.Price())
      .RuleFor(c => c.Description, f => f.Commerce.ProductAdjective())
      .RuleFor(c => c.ImageUrl, (f, i) => f.Image.LoremFlickrUrl(480, 480, i.Item, false, true));

    var testUsers = new Faker<User>()
      .RuleFor(u => u.Id, f => userIds++)
      .RuleFor(u => u.FirstName, (f, u) => f.Name.FirstName())
      .RuleFor(u => u.LastName, (f, u) => f.Name.LastName())
      .RuleFor(u => u.Username, (f, u) => f.Internet.UserName(u.FirstName, u.LastName))
      .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.FirstName, u.LastName))
      .RuleFor(u => u.Products, f => testProducts.Generate(3).ToList());

    var user = testUsers.Generate();

    await SendAsync(user, cancellation: ct);
  }
}