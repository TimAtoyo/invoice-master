using Microsoft.EntityFrameworkCore;
namespace invoice_master.Data;
//DbContedtClass to act as a bridge between entiry framework and the database
//Inherits DBContext class from entity framework
public class AppDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    // costructor to pass options of type AppDbContext - to be used in in program.cs to use injection
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
}
