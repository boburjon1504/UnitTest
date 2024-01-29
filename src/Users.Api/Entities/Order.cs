namespace Users.Api.Entities;

public class Order
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public DateTimeOffset OrderedDate { get; set; }

    public decimal Amount { get; set; }
}
