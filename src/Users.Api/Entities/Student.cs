using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace Users.Api.Entities;

public class Student : User
{
    public string ParentPhoneNumber { get; set; }

    public string ParentName { get; set; }
}
