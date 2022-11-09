namespace SimCube.Spartan.Extensions;

/// <summary>
/// Common extension methods for Reflection.
/// </summary>
public static class ReflectionExtensions
{
    /// <summary>
    /// Checks if a type inherits from another.
    /// </summary>
    /// <param name="t1">The type to check.</param>
    /// <param name="t2">The type to check against.</param>
    /// <returns>True if it is assignable, false if not.</returns>
    public static bool InheritsFrom(this Type? t1, Type? t2)
    {
        if (t1 == null || t2 == null)
        {
            return false;
        }

        if (t1.BaseType is { IsGenericType: true } && t1.BaseType.GetGenericTypeDefinition() == t2)
        {
            return true;
        }

        if (InheritsFrom(
                t1.BaseType,
                t2))
        {
            return true;
        }

        return
            (t2.IsAssignableFrom(t1) && t1 != t2) ||
            t1.GetInterfaces().Any(
                x => x.IsGenericType &&
                     x.GetGenericTypeDefinition() == t2);
    }
}
