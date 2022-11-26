using ToyShopAPI.Entities.User;
using ToyShopAPI.Models;

namespace ToyShopAPI.Features.Auth.Signup;

public interface ISignupData
{
  Task<bool> EmailIsTaken(string email);
  Task<bool> UsernameIsTaken(string username);
  Task Signup(User user);
}

public class SignupData : ISignupData
{
  private readonly toyshopapiContext _context;
  public SignupData(toyshopapiContext context)
  {
    _context = context;
  }

  public async Task<bool> EmailIsTaken(string email)
  {
    return await _context.Users
                    .AnyAsync(e => e.Email == email);
  }

  public async Task<bool> UsernameIsTaken(string username)
  {
    return await _context.Users
                    .AnyAsync(e => e.Username.ToLower() == username);
  }

  public Task Signup(User user)
  {
    user.Role = !_context.Users.Any() ? (int)Role.Admin : (int)Role.User;
    _context.Users.Add(user);
    return _context.SaveChangesAsync();
  }
}
