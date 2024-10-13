using System;

public abstract class BaseTypeInspector
{
    protected void PrintBasicTypeInfo(Type type)
    {
        Console.WriteLine($"Type: {type.Name}");
        Console.WriteLine($"Base Type: {type.BaseType?.Name ?? "None"}");
        Console.WriteLine("Interfaces:");
        foreach (Type interfaceType in type.GetInterfaces())
        {
            Console.WriteLine($"  {interfaceType.Name}");
        }
    }

    public abstract void InspectType(Type type, object instance);
}
