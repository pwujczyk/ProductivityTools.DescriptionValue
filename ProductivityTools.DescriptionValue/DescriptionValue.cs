using System;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace ProductivityTools.DescriptionValue
{
    public static class DescriptionValue
    {
        private static FieldInfo GetEnumFieldInfo(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            return fi;
        }

        public static bool DescriptionExists(this Enum value)
        {
            var fi = value.GetEnumFieldInfo();
            var r = DescriptionExists(fi);
            return r;
        }

        public static string GetDescription(this Enum value)
        {
            var fi = value.GetEnumFieldInfo();
            return GetDescriptionValue(fi);
        }

        public static string DescriptionExists(this Type value)
        {
            return DescriptionExists(value);
        }


        public static string GetDescription(this Type value)
        {
            return GetDescriptionValue(value);
        }

        private static PropertyInfo GetPropertyInfo(this Type @class, string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName)) throw new ArgumentException($"Please provide {nameof(propertyName)}");
            var property = @class.GetProperty(propertyName);
            return property;
        }

        public static bool PropertyDescriptionExists(this Type @class, string propertyName)
        {
            var property = @class.GetPropertyInfo(propertyName);
            return DescriptionExists(property);
        }

        public static string GetPropertyDescription(this Type @class, string propertyName)
        {
            var property = @class.GetPropertyInfo(propertyName);
            return GetDescriptionValue(property);
        }

        private static MethodInfo GetMethodInfo(this Type @class, string methodName)
        {
            if (string.IsNullOrEmpty(methodName)) throw new ArgumentException($"Please provide {nameof(methodName)}");
            MethodInfo method = @class.GetMethod(methodName);
            return method;
        }

        public static bool MethodDescriptionExists(this Type @class, string methodName)
        {
            MethodInfo methodInfo = @class.GetMethodInfo(methodName);
            return DescriptionExists(methodInfo);
        }

        public static string GetMethodDescription(this Type @class, string methodName)
        {
            MethodInfo methodInfo = @class.GetMethodInfo(methodName);
            return GetDescriptionValue(methodInfo);
        }

        private static FieldInfo GetFieldInfo(this Type type, string fieldName)
        {
            if (string.IsNullOrEmpty(fieldName)) throw new ArgumentException($"Please provide {nameof(fieldName)}");
            var field = type.GetField(fieldName);
            return field;   
        }

        public static bool FieldDescriptionExists(this Type type, string fieldName)
        {
            FieldInfo field = type.GetFieldInfo(fieldName);
            return DescriptionExists(field);
        }

        public static string GetFieldDescription(this Type type, string fieldName)
        {
            FieldInfo field = type.GetFieldInfo(fieldName);
            return GetDescriptionValue(field);
        }



        private static T DescriptionSelector<T>(ICustomAttributeProvider provider, 
            Func<DescriptionAttribute[], T> trueSelector,
            Func<DescriptionAttribute[], T> falseSelector)
        {
            DescriptionAttribute[] attributes =
               provider.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];
            if (attributes != null && attributes.Length > 0)
            {
                return trueSelector(attributes);
            }
            else
            {
                return falseSelector(attributes);
            }
        }

        private static bool DescriptionExists(ICustomAttributeProvider provider)
        {
            var r = DescriptionSelector(provider, (x) => true, (x) => false);
            return r;
        }

        private static string GetDescriptionValue(ICustomAttributeProvider provider)
        {
            var r=DescriptionSelector(provider, (x) => x[0].Description, (x) => throw new Exception("Missing Description attribute"));
            return r;
        }
    }
}
