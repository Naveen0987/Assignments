using System;
using System.Reflection;

public class TypePropertyInspector : ITypePropertyInspector
{
    public void PrintProperties(Type type, object instance)
    {
        PropertyInfo[] properties = type.GetProperties();
        Console.WriteLine("Properties:");

        if (properties.Length > 0)
        {
            foreach (PropertyInfo property in properties)
            {
                object value = property.GetValue(instance);
                Console.WriteLine($"  {property.Name}: {value}");
            }
        }
        else
        {
            Console.WriteLine("  None");
        }

        Console.WriteLine();
    }
}
