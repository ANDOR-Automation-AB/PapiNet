using Microsoft.Extensions.Logging;
using System.Reflection;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace PapiNet;

public static class Extensions
{
    public static XElement? ToXElement(this object? obj)
    {
        if (obj == null)
            return null;
        return new XElement(obj.GetType().Name);
    }

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

    public static T ToEnum<T>(this string value, ILogger<PapiNet.Old.DeliveryMessageWood>? logger = null) where T : struct, Enum
    {
        try
        {
            return (T)Enum.Parse(typeof(T),
                typeof(T).GetTypeInfo()
                    .DeclaredMembers
                    .SingleOrDefault(mi => mi.GetCustomAttribute<EnumMemberAttribute>(false)?.Value == value)
                    ?.Name ?? value,
                true);
        }
        catch (Exception e)
        {
            logger?.LogError(e, e.Message);
            return default;
        }
    }
}
