using System;
using System.Reflection;

class Program
{
    static void Main(string[] args)
    {
        ITypeInfoPrinter typeInfoPrinter = new TypeInfoPrinter();
        ITypePropertyInspector propertyInspector = new TypePropertyInspector();
        ITypeFieldInspector fieldInspector = new TypeFieldInspector();

        IAssemblyInspector inspector = new AssemblyInspector(typeInfoPrinter, propertyInspector, fieldInspector);

        Assembly assembly = Assembly.GetExecutingAssembly();

        var instance = new SampleClass();

        inspector.InspectType(assembly, "SampleClass", instance);

        Console.ReadLine();
    }
}
