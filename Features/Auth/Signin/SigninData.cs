using ToyShopAPI.Models;

namespace ToyShopAPI.Features.Auth.Signin;

public interface ISigninData
{
  Task<User> GetEmail(string email);
}

public class SigninData : ISigninData
{
  private readonly toyshopapiContext _context;
  public SigninData(toyshopapiContext context)
  {
    _context = context;
  }

  public async Task<User> GetEmail(string email)
  {
    return await _context.Users
                    .FirstOrDefaultAsync(e => e.Email == email);
  }
}