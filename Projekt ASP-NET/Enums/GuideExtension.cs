using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Projekt_ASP_NET.Enums
{
    static public class GuideExtension
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            return enumValue.GetType()
                .GetMember(enumValue.ToString())
                .First()
                .GetCustomAttribute<DisplayAttribute>()
                .GetName();
        }
    }
}
