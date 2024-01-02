using System.ComponentModel.DataAnnotations;

namespace MapsAndToolsUI.Components;

public static class EnumExtensions
{
    public static string GetDisplayName(this Enum value)
    {
        var field = value.GetType().GetField(value.ToString());
        var displayAttribute = (DisplayAttribute)Attribute.GetCustomAttribute(field, typeof(DisplayAttribute));

        return displayAttribute?.Name ?? value.ToString();
    }
}
