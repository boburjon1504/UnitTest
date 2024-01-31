

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using ReflectionPractise;
using System.Reflection;
using System.Text.Json;


var post = typeof(IEntity);

var assambly = Assembly.GetExecutingAssembly().GetTypes();




Console.WriteLine();

foreach(var assembly in assambly)
{
    if(!post.Name.Equals(assembly.Name) && post.IsAssignableFrom(assembly))
    {
        Console.WriteLine($"{assembly.Name} is   {post.Name}");
        Console.WriteLine();
        var type = assembly.GetInterfaces().FirstOrDefault(x=>x.Name.Contains("IEntityTypeConfiguration")).GetGenericArguments().FirstOrDefault();
        //foreach(var arg in a)
        //{
        //    if(arg.IsGenericType)
        //    {
        //        Console.WriteLine(arg.Name + "  " + assembly.Name);
        //        foreach(var type in arg.GetGenericArguments())
        //        {
        //            Console.WriteLine(type.Name);
        //        }
        //    }
        //}
    }
    else
    {

    }
}

Console.WriteLine(post.IsAssignableFrom(typeof(User)));
