using System.Reflection;
using System.Runtime.Serialization;

namespace PapiNet;

public static class Extensions
{
    public static string Value<T>(this T value) where T : Enum
    {
        return typeof(T)
            .GetTypeInfo()
            .DeclaredMembers
            .SingleOrDefault(mi => mi.Name == $"{value}")
            ?.GetCustomAttribute<EnumMemberAttribute>(false)
            ?.Value ?? $"{value}";
    }
}

