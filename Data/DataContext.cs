using ToyShopAPI.Entities.User;

namespace ToyShopAPI.Data;

public class DataContext : DbContext
{
  public DataContext(DbContextOptions options) : base(options) { }
}
