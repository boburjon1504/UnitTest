using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Users.Api.Entities;
using Users.Api.EntityConfigurations;

namespace Users.Api.DataAccess;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Order> Orders => Set<Order>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var types = Assembly.GetExecutingAssembly().GetTypes();

        var order = typeof(IOrder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly,
            x => x.GetInterfaces().Any(y => y.Name.Equals(nameof(IOrder))));
    }
}
