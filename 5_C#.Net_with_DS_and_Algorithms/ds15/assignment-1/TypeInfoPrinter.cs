using System;

public class TypeInfoPrinter : ITypeInfoPrinter
{
    public void PrintTypeInfo(Type type)
    {
        Console.WriteLine($"Type: {type.Name}");
    }
}
