using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace ProductivityTools.DescriptionValue
{
    public static class DescriptionValue
    {
        public static string GetDescription(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute attribute = fi.GetCustomAttribute(typeof(DescriptionAttribute)) as DescriptionAttribute;

            if (attribute != null )
            {
                return attribute.Description;
            }

            return value.ToString();
        }

        public static string GetDescription(this Type @class,string propertyName)
        {
            var property = @class.GetProperty(propertyName);
            DescriptionAttribute attribute = property.GetCustomAttribute(typeof(DescriptionAttribute)) as DescriptionAttribute;
            return attribute.Description;
        }
    }
}
