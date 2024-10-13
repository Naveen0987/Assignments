using System;
using System.Reflection;

public class AssemblyInspector : IAssemblyInspector
{
    private readonly ITypeInfoPrinter _typeInfoPrinter;
    private readonly ITypePropertyInspector _propertyInspector;
    private readonly ITypeFieldInspector _fieldInspector;

    // Constructor for dependency injection
    public AssemblyInspector(ITypeInfoPrinter typeInfoPrinter, ITypePropertyInspector propertyInspector, ITypeFieldInspector fieldInspector)
    {
        _typeInfoPrinter = typeInfoPrinter;
        _propertyInspector = propertyInspector;
        _fieldInspector = fieldInspector;
    }

    public void InspectType(Assembly assembly, string typeName, object instance)
    {
        Type type = assembly.GetType(typeName);

        if (type != null)
        {
            Console.WriteLine($"=== Inspecting Type: {type.Name} ===");

            // Print basic type information
            _typeInfoPrinter.PrintTypeInfo(type);

            // Print public properties
            _propertyInspector.PrintProperties(type, instance);

            // Print public fields
            _fieldInspector.PrintFields(type, instance);
        }
        else
        {
            Console.WriteLine($"Type '{typeName}' not found in the assembly.");
        }
    }
}
