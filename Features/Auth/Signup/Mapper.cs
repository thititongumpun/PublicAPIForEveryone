using ToyShopAPI.Models;

namespace ToyShopAPI.Features.Auth.Signup;

public class Mapper : Mapper<Request, Response, User>
{
  public override User ToEntity(Request r) => new()
  {
    Email = r.Email,
    Username = r.Username,
    FirstName = r.FirstName,
    LastName = r.LastName,
    Password = BCrypt.Net.BCrypt.HashPassword(r.Password),
    CreatedAt = DateTime.Now
  };
}


