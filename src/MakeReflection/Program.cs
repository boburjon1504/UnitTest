// See https://aka.ms/new-console-template for more information

using MakeReflection;
using System;
using System.Reflection;
using System.Text;

var user = new User
{
    FirstName = "Bobur",
    LastName = "Joraboyev",
    UserName = "bobur_jr"
};

string message = "Dear {{UserName}}, Sening isming {{FirstName}} {{LastName}} va id - {{_id}}";
var type = user.GetType();
var placeholder = GetPlaceHolders(message);
var a = type.GetProperties();

var first = a[0];

var s= Activator.CreateInstance(first.PropertyType);
Console.WriteLine((first.PropertyType.)first.GetValue(user));

message.Replace("{{UserName}}", "e");

Console.WriteLine($"Before : {message}");

placeholder.ForEach(x =>
{
    var property = a.FirstOrDefault(y => y.Name.Equals(x.value));

    if(property is not null)
    {
        var value = property.GetValue(user);
        message = message.Replace(x.placeHolder, value.ToString());
    }
});

Console.WriteLine($"After : {message}");


foreach (var property in a)
{
    Console.WriteLine(property.GetValue(user));
}

static List<(string placeHolder, string value)> GetPlaceHolders(string message)
{
    var placeHolders = new List<(string placeHolder, string value)>();
    var a = new StringBuilder();

    for(int i = 0; i < message.Length; i++)
    {
        if(message[i] == '{')
        {
            a.Append("{{");
            i++;
        }
        else if(message[i] == '}')
        {
            a.Append("}}");
            placeHolders.Add((a.ToString(), a.ToString().Replace("{", "").Replace("}", "")));
            a = new StringBuilder();
            i++;
        }
        else if(a.Length > 0)
        {
            a.Append(message[i]);
        }
    }

    return placeHolders;
}