using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Users.Api.Entities;

namespace Users.Api.EntityConfigurations;

public class StudentsConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasData(new Student
        {
            Id = Guid.NewGuid(),
            Role = Role.Student,
            ParentName = "parent",
            ParentPhoneNumber = "parentNumber",
        });
    }
}
