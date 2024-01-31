using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionPractise;
public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //modelBuilder.ApplyConfiguration<User>(new User());
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly,x=>x.GetInterfaces().Any(x=>x.Name.Equals(nameof(IEntity))));
    }
}
