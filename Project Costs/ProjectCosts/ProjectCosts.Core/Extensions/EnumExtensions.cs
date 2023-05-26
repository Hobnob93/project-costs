using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ProjectCosts.Core.Extensions;

public static class EnumExtensions
{
    public static TAttr? GetAttribute<TAttr>(this System.Enum enumVal, bool throwIfNotFound = false) where TAttr : Attribute
    {
        var attr = enumVal.GetType()
            ?.GetMember(enumVal.ToString())
            ?.Single()
            .GetCustomAttribute<TAttr>();

        if (attr is null && throwIfNotFound)
            throw new InvalidOperationException($"{enumVal.GetType()}::{enumVal} has no attribute {typeof(TAttr)}");

        return attr;
    }

    public static string GetDisplayName(this System.Enum enumVal)
    {
        var attr = enumVal.GetAttribute<DisplayAttribute>();

        return attr?.Name
            ?? enumVal.ToString();
    }
}
