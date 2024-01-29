using FindNumber;
using System.Reflection.Metadata;
using FluentAssertions;
namespace ThereIsATest;

public class UnitTest1
{

    [Fact]
    public void Test1()
    {
        var a = new GuestTheNumber();
        a.FirstName = "Boburjon";
        a.FirstName.Should().HaveLength(10,"we expect it");

        Assert.Null (a.LastName);
    }

    [Theory]
    [InlineData(1,2,3)]
    public void A(int a,int b,int s)
    {
        var c = a + b + s;

        c.Should().Be(10);
    }
}