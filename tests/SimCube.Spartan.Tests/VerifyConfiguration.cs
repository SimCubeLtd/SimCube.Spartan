using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace SimCube.Spartan.Tests;

[ExcludeFromCodeCoverage]
public static class VerifyConfiguration
{
    [ModuleInitializer]
    public static void Init()
    {
        VerifierSettings.DerivePathInfo((_, project, type, method) =>
        {
            var root = Path.Combine(project, "Expectations");
            return GetFallbackPathInfo(root, type, method);
        });
    }

    private static PathInfo GetFallbackPathInfo(string root, Type type, MethodInfo method)
    {
        return new PathInfo(
            directory: root,
            typeName: GetTypeName(type),
            methodName: method.Name);
    }

    private static string GetTypeName(Type type)
    {
        var typeName = type.FullName;
        var index = type.FullName!.LastIndexOf('.');

        if (index != -1)
        {
            typeName = type.FullName.Substring(index + 1);
        }

        return typeName!.Replace('+', '.');
    }
}