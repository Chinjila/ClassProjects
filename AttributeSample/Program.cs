// See https://aka.ms/new-console-template for more information



using System.Linq;
using System.Reflection;
using System.Security.Principal;

Target x = new Target();
var loggingAttribute2 = typeof(Target).GetCustomAttribute<LoggingAttribute>();
if (loggingAttribute2 != null) {
    if (loggingAttribute2.Destination == "File")
    {
        Console.WriteLine($"Logging something to file from {loggingAttribute2.ProgramName}");
    }
}

foreach (Attribute attribute in typeof(Target).GetCustomAttributes()){
    if (attribute is LoggingAttribute loggingAttribute) { 
        if (loggingAttribute.Destination == "File") {
            Console.WriteLine($"Logging something to file from {loggingAttribute.ProgramName}");
        }
    }
}


x.MethodA(5);

public class LoggingAttribute : Attribute
{
    public string Destination;
    public string ProgramName { get; }
    public LoggingAttribute(string programName)
    {
        ProgramName = programName;
    }
}

[Logging("AttributeSample",Destination ="File")]
public class Target
{

    public void MethodA(int x) {
        
        
    }
}