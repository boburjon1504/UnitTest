using Users.Api.Entities;
using Users.Api.Repository.Interface;

namespace Users.Api.Services;

public class UserService(IUserRepository repository)
{
    public ValueTask<User> CreateAsync(User user)
    {
        if(user.FirstName is null || user.LastName is null || !user.EmailAddress.Contains("@") || user.Password.Length < 8)
        {
            throw new FormatException();
        }

        return repository.CreateAsync(user);
    }
}
