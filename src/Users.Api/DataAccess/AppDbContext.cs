using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Users.Api.Entities;
using Users.Api.EntityConfigurations;

namespace Users.Api.DataAccess;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<Admin> Admins => Set<Admin>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Student> Students => Set<Student>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var types = Assembly.GetExecutingAssembly().GetTypes();

        var order = typeof(IOrder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
