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
            if (string.IsNullOrEmpty(propertyName)) throw new ArgumentException($"Please provide {nameof(propertyName)}");
            var property = @class.GetProperty(propertyName);
            return GetDescription(property);
        }

        public static string GetMethodDescription(this Type @class, string methodName)
        {
            if (string.IsNullOrEmpty(methodName)) throw new ArgumentException($"Please provide {nameof(methodName)}");
            var method = @class.GetMethod(methodName);
            return GetDescription(method);
        }

        public static string GetFieldDescription(this Type type, string fieldName)
        {
            if (string.IsNullOrEmpty(fieldName)) throw new ArgumentException($"Please provide {nameof(fieldName)}");
            var field = type.GetField(fieldName);
            return GetDescription(field);
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
