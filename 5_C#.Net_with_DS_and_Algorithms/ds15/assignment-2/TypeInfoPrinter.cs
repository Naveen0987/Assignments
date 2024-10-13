using System;

public class TypeInfoPrinter : BaseTypeInspector, ITypeInfoPrinter
{
    public void PrintTypeInfo(Type type)
    {
        // This method should ideally be used for basic type info. You can also use InspectType if needed.
        PrintBasicTypeInfo(type);
    }

    public override void InspectType(Type type, object instance)
    {
        PrintTypeInfo(type);
    }
}
