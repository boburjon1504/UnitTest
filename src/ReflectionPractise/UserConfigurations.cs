using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ReflectionPractise;
public class UserConfigurations : IEntityTypeConfiguration<User>,IEntity
{
    public void Configure(EntityTypeBuilder<User> builder)
    {

    }
}
