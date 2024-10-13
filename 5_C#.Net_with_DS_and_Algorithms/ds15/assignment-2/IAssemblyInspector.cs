using System.Reflection;

public interface IAssemblyInspector
{
    void InspectType(Assembly assembly, string typeName, object instance);
}
