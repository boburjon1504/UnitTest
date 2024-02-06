using Users.Api.Entities;

namespace Users.Api.Repository.Interface;

public interface IUserRepository
{
    IQueryable<User> Get();

    ValueTask<dynamic?> GetByIdAsync<T>(Guid id) where T : class,IEntity;

    ValueTask<User> CreateAsync(User user);

    ValueTask<User> UpdateAsync(User user);

    ValueTask<User> DeleteByIdAsync(Guid id);
}
