using System;
using System.Reflection;

public class TypeFieldInspector : ITypeFieldInspector
{
    public void PrintFields(Type type, object instance)
    {
        FieldInfo[] fields = type.GetFields();
        Console.WriteLine("Fields:");

        if (fields.Length > 0)
        {
            foreach (FieldInfo field in fields)
            {
                object value = field.GetValue(instance);
                Console.WriteLine($"  {field.Name}: {value}");
            }
        }
        else
        {
            Console.WriteLine("  None");
        }

        Console.WriteLine();
    }
}
