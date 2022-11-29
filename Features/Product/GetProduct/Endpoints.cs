using System.Security.Claims;
namespace ToyShopAPI.Features.Product.GetProduct;

public class Endpoints : Endpoint<Request>
{
  public override void Configure()
  {
    Get("/product/get-product/{ProductId}");
    AllowAnonymous();
  }

  public override async Task HandleAsync(Request r, CancellationToken ct)
  {
    await SendAsync(
        await ProductData.GetProduct(r.ProductId.ToString()), cancellation: ct);
  }
}
