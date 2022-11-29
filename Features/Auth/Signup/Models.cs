namespace ToyShopAPI.Features.Auth.Signup;

public class Request
{
  public string Email { get; set; }
  public string Username { get; set; }
  public string Password { get; set; }
  public string FirstName { get; set; }
  public string LastName { get; set; }
  public int? Role { get; set; }
  public DateTime? CreatedAt { get; set; }
}

public class Validator : Validator<Request>
{
  public Validator()
  {
    RuleFor(x => x.Email)
            .NotEmpty().WithMessage("email address is required!")
            .EmailAddress().WithMessage("the format of your email address is wrong!");

    RuleFor(x => x.Username)
        .NotEmpty().WithMessage("a username is required!")
        .MinimumLength(3).WithMessage("username is too short!")
        .MaximumLength(15).WithMessage("username is too long!");

    RuleFor(x => x.Password)
        .NotEmpty().WithMessage("a password is required!")
        .MinimumLength(3).WithMessage("password is too short!")
        .MaximumLength(15).WithMessage("password is too long!");
  }
}

public class Response
{
  public string Message { get; set; }
}