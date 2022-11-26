namespace ToyShopAPI.Features.Auth.Signin;

public class Request
{
  public string Email { get; set; }
  public string Password { get; set; }
}

public class Validator : Validator<Request>
{
  public Validator()
  {
    RuleFor(x => x.Email)
            .NotEmpty().WithMessage("email address is required!")
            .EmailAddress().WithMessage("the format of your email address is wrong!");

    RuleFor(x => x.Password)
        .NotEmpty().WithMessage("a password is required!")
        .MinimumLength(3).WithMessage("password is too short!")
        .MaximumLength(15).WithMessage("password is too long!");
  }
}

public class Response
{
  public string Access_Token { get; set; }
}