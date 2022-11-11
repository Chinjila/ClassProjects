// See https://aka.ms/new-console-template for more information
using System.Reflection;

//Entry point to Reflect is a Type
Object o;
if (Random.Shared.Next(100) % 2 == 0)
{ 
    o = new Dictionary<string, string>(); 
}
else 
{
    o = new List<string>();
}



Type aThing   = o.GetType();

Console.WriteLine($"{aThing.Name } is abstract? {aThing.IsAbstract}");
Console.WriteLine($"{aThing.Name} is a class? {aThing.IsClass}");
Console.WriteLine($"{aThing.Name} has {aThing.GetMethods().Count()} methods");
Console.WriteLine($"{aThing.Name} has {aThing.GetFields().Count()} fields");

Console.WriteLine($"Here are the public methods of {aThing.Name}");
foreach (var method in aThing.GetMethods())
{
    Console.WriteLine($"\t{method.Name} returns {method.ReturnType} and accepts {method.GetParameters().Length} parameters");    
}

//populate the list or dictionary with a few entries
// Add - dictionary takes two params while list accepts 1
if (o is List<string>)
{
    Console.WriteLine("its a list");
    var aList = o as List<string>;
    aList?.Add("test list");
}
else if (o is Dictionary<string, string>)
{
    Console.WriteLine("its a dictionary");
    var aDictionary = o as Dictionary<string, string>;
    aDictionary?.Add("SomeKey", "SomeValue");
}

MethodInfo? addMethod = aThing.GetMethod("Add");// use Runtime Reflection to pull the method definition for "Add"

if (addMethod.GetParameters().Length == 1)
{
    addMethod.Invoke(o, new Object[] { "test List2" });
}
else
{
    addMethod.Invoke(o, new Object[] { "SomeKey2","SomeValue2" });
}



Console.ReadLine();


