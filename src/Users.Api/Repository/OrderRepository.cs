using Microsoft.EntityFrameworkCore;
using Users.Api.DataAccess;
using Users.Api.Entities;
using Users.Api.Repository.Interface;

namespace Users.Api.Repository;

public class OrderRepository(AppDbContext dbContext) : IOrderRepository
{
    public async ValueTask<Order> CreateAsync(Order order)
    {
        await dbContext.Orders.AddAsync(order);

        await dbContext.SaveChangesAsync();

        return order;
    }

    public async ValueTask<Order> DeleteByIdAsync(Guid id)
    {
        var order = await GetByIdAsync(id);

        dbContext.Remove(order);

        await dbContext.SaveChangesAsync();

        return order;
    }

    public IQueryable<Order> Get()
    {
        return dbContext.Orders;
    }

    public async ValueTask<Order?> GetByIdAsync(Guid id)
    {
        return await dbContext.Orders.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async ValueTask<Order> UpdateAsync(Order order)
    {
        dbContext.Orders.Update(order);

        await dbContext.SaveChangesAsync();

        return order;
    }
}
