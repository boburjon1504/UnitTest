using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Users.Api.Entities;

namespace Users.Api.EntityConfigurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>,IOrder
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
       
    }
}
