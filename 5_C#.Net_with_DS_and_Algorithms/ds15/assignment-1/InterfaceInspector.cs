using System;

public class InterfaceInspector : IInterfaceInspector
{
    public void PrintInterfaces(Type type)
    {
        Type[] interfaces = type.GetInterfaces();
        Console.WriteLine("Interfaces:");
        if (interfaces.Length > 0)
        {
            foreach (Type interfaceType in interfaces)
            {
                Console.WriteLine($"  {interfaceType.Name}");
            }
        }
        else
        {
            Console.WriteLine("  None");
        }
    }
}
