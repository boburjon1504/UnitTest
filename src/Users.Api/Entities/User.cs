namespace Users.Api.Entities;

public abstract class User : IEntity
{
    public Guid Id { get; set; }

    public Role Role { get; set; }
    
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? EmailAddress { get; set; }

    public string? Password { get; set; }
}
