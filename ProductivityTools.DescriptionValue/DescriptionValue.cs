using System;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Reflection;

namespace ProductivityTools.DescriptionValue
{
    public static class DescriptionValue
    {
        public static string GetDescription(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            return GetDescription(fi);
        }

        public static string GetPropertyDescription(this Type @class, string propertyName)
        {
            var property = @class.GetProperty(propertyName);
            return GetDescription(property);
        }

        public static string GetMethodDescription(this Type @class, string methodName)
        {
            var method = @class.GetMethod(methodName);
            return GetDescription(method);
        }

        private static string GetDescription(ICustomAttributeProvider provider)
        {
            DescriptionAttribute[] attributes = provider.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attributes != null && attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            return string.Empty;
        }
    }
}
