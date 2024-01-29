using Users.Api.Repository.Interface;
using FakeItEasy;
using Users.Api.Services;
using Users.Api.Entities;
using FluentAssertions;
namespace ThereIsATest;

public class UserServiceTest
{
    private readonly IUserRepository userRepository;

    private readonly UserService userService;

    public UserServiceTest()
    {
        userRepository = A.Fake<IUserRepository>();
        userService = new UserService(userRepository);
    }
    [Fact]
    public async Task CreateAsync_Should_Have_An_FormatingError()
    {
        var user = new User
        {
            FirstName = "Test",
            LastName = "Test",
            EmailAddress = "Test",
            Password = "Test",
        };

        Action resultAction = async () => await userService.CreateAsync(user);

        resultAction.Should().Throw<FormatException>();
    }
}
