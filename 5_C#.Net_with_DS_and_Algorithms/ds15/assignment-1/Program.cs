using System;
using System.Reflection;

class Program
{
    static void Main(string[] args)
    {
        ITypeInfoPrinter typeInfoPrinter = new TypeInfoPrinter();
        IBaseTypeInspector baseTypeInspector = new BaseTypeInspector();
        IInterfaceInspector interfaceInspector = new InterfaceInspector();

        IAssemblyInspector inspector = new AssemblyInspector(typeInfoPrinter, baseTypeInspector, interfaceInspector);

        Assembly assembly = Assembly.GetExecutingAssembly();

        inspector.InspectAssembly(assembly);

        Console.ReadLine();
    }
}
