using System;

public class BaseTypeInspector : IBaseTypeInspector
{
    public void PrintBaseType(Type type)
    {
        Console.WriteLine($"Base Type: {type.BaseType?.Name ?? "None"}");
    }
}
