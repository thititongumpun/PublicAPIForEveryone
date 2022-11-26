namespace ToyShopAPI.Features.Auth.Signup;

public class Endpoint : Endpoint<Request, Response, Mapper>
{
  public ISignupData dataService { get; set; }
  public override void Configure()
  {
    Post("/signup");
    Version(1);
    AllowAnonymous();
  }

  public override async Task HandleAsync(Request r, CancellationToken ct)
  {
    var user = Map.ToEntity(r);

    var emailIsTaken = await dataService.EmailIsTaken(r.Email);

    if (emailIsTaken)
      AddError(r => r.Email, "sorry! email address is already in use...");

    var userNameIsTaken = await dataService.UsernameIsTaken(r.Username.ToLower());

    if (userNameIsTaken)
      AddError(r => r.Username, "sorry! that username is not available...");

    ThrowIfAnyErrors();

    await dataService.Signup(user);

    await SendAsync(new()
    {
      Message = "Signup successfully."
    }, cancellation: ct);
  }
}