using System.Reflection;
using System.Runtime.Serialization;

namespace PapiNet;

public static class Extensions
{
    public static string GetMemberValue<T>(this T? value) where T : struct, Enum
    {
        if (value == null)
            return string.Empty;
        return typeof(T)
            .GetTypeInfo()
            .DeclaredMembers
            .SingleOrDefault(mi => mi.Name == $"{value}")
            ?.GetCustomAttribute<EnumMemberAttribute>(false)
            ?.Value ?? $"{value}";
    }

    public static string GetMemberValue<T>(this T value) where T : struct, Enum
    {
        return typeof(T)
            .GetTypeInfo()
            .DeclaredMembers
            .SingleOrDefault(mi => mi.Name == $"{value}")
            ?.GetCustomAttribute<EnumMemberAttribute>(false)
            ?.Value ?? $"{value}";
    }

    public static T ToEnum<T>(this string value) where T : struct, Enum
    {
        return (T)Enum.Parse(typeof(T),
            typeof(T).GetTypeInfo()
                .DeclaredMembers
                .SingleOrDefault(mi => mi.GetCustomAttribute<EnumMemberAttribute>(false)?.Value == value)
                ?.Name ?? value,
            true);
    }
}
