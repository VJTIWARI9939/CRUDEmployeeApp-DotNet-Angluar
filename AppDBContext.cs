using Microsoft.EntityFrameworkCore;

namespace crud_dot_net_api.Data
{
  public class AppDBContext : DbContext
  {
    public AppDBContext(DbContextOptions<AppDBContext> options): base(options) {
      // Constructor
    }
    public DbSet<Employee> Employees { get; set; } // Table initialize
  }
}
