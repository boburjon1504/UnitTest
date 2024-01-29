using Users.Api.Entities;

namespace Users.Api.Repository.Interface;

public interface IOrderRepository
{
    IQueryable<Order> Get();

    ValueTask<Order> GetByIdAsync(Guid id);

    ValueTask<Order> CreateAsync(Order order);

    ValueTask<Order> UpdateAsync(Order order);

    ValueTask<Order> DeleteByIdAsync(Guid id);
}
