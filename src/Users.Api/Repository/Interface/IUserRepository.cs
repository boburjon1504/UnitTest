using Users.Api.Entities;

namespace Users.Api.Repository.Interface;

public interface IUserRepository
{
    IQueryable<User> Get();

    ValueTask<User> GetByIdAsync(Guid id);

    ValueTask<User> CreateAsync(User user);

    ValueTask<User> UpdateAsync(User user);

    ValueTask<User> DeleteByIdAsync(Guid id);
}
