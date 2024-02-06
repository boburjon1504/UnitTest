using Microsoft.EntityFrameworkCore;
using Users.Api.DataAccess;
using Users.Api.Entities;
using Users.Api.Repository.Interface;

namespace Users.Api.Repository;

public class UserRepository(AppDbContext dbContext) : IUserRepository
{
    public async ValueTask<User> CreateAsync(User user)
    {
        //await dbContext.Users.AddAsync(user);

        await dbContext.SaveChangesAsync();

        return user;
    }

    public async ValueTask<User> DeleteByIdAsync(Guid id)
    {
        //var user = await GetByIdAsync(id);

        //dbContext.Remove(user);

        //await dbContext.SaveChangesAsync();

        return null ;
    }

    public IQueryable<User> Get()
    {
        return dbContext.Users;
        //return dbContext.Users;
    }

    public async ValueTask<dynamic?> GetByIdAsync<T>(Guid id) where T : class,IEntity
    {
        return  await dbContext.FindAsync<T>(id);

        //return await dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async ValueTask<User> UpdateAsync(User user)
    {
        //dbContext.Users.Update(user);

        await dbContext.SaveChangesAsync();

        return user;
    }
}
