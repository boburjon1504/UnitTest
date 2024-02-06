using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Users.Api.Entities;

namespace Users.Api.EntityConfigurations;

public class AdminConfiguration : IEntityTypeConfiguration<Admin>
{
    public void Configure(EntityTypeBuilder<Admin> builder)
    {
        builder.HasData(new Admin
        {
            Id = Guid.NewGuid(),
            Salary = 1000,
            Role = Role.Admin,
            FirstName = "Test",
            LastName = "Test",
        });
    }
}
