using ToyShopAPI.Entities.User;
using ToyShopAPI.Helpers;

namespace ToyShopAPI.Features.Auth.Signin;

public class Endpoint : Endpoint<Request>
{
  public ISigninData dataService { get; set; }

  public override void Configure()
  {
    Post("/signin");
    Version(1);
    AllowAnonymous();
  }

  public override async Task HandleAsync(Request r, CancellationToken ct)
  {
    var user = await dataService.GetEmail(r.Email);

    if (user == null)
      ThrowError("User not found");

    if (user == null || !BCrypt.Net.BCrypt.Verify(r.Password, user.Password))
      ThrowError("User or password is incorrect");

    Role userRole = new EnumHelper().GetEnumValue<Role>((int)user.Role);

    var userPermission = new[]
    {
      userRole.ToString()
    };

    var jwtToken = JWTBearer.CreateToken(
        signingKey: Config["JwtSigningKey"],
        expireAt: DateTime.UtcNow.AddDays(1),
        claims: new[] { ("Username", user.Username), (userRole.ToString(), userRole.ToString()) },
        roles: new[] { userRole.ToString() },
        permissions: userPermission);

    await SendAsync(new
    {
      Access_token = jwtToken
    }, cancellation: ct);
  }
}