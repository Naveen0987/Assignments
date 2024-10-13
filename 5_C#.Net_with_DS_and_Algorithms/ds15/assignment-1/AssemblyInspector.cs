using System;
using System.Reflection;

public class AssemblyInspector : IAssemblyInspector
{
    private readonly ITypeInfoPrinter _typeInfoPrinter;
    private readonly IBaseTypeInspector _baseTypeInspector;
    private readonly IInterfaceInspector _interfaceInspector;

    // Constructor to inject dependencies
    public AssemblyInspector(ITypeInfoPrinter typeInfoPrinter, IBaseTypeInspector baseTypeInspector, IInterfaceInspector interfaceInspector)
    {
        _typeInfoPrinter = typeInfoPrinter;
        _baseTypeInspector = baseTypeInspector;
        _interfaceInspector = interfaceInspector;
    }

    public void InspectAssembly(Assembly assembly)
    {
        Console.WriteLine("=== Assembly Inspection ===");

        foreach (Type type in assembly.GetTypes())
        {
            // Use the different inspectors
            _typeInfoPrinter.PrintTypeInfo(type);
            _baseTypeInspector.PrintBaseType(type);
            _interfaceInspector.PrintInterfaces(type);

            Console.WriteLine(); // Separate output for readability
        }
    }
}
