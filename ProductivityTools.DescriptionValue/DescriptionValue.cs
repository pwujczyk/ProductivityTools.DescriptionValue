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

            DescriptionAttribute attribute = fi.GetCustomAttribute(typeof(DescriptionAttribute)) as DescriptionAttribute;

            if (attribute != null)
            {
                return attribute.Description;
            }

            return value.ToString();
        }

        public static string GetDescription(this Type @class, string propertyName)
        {
            var property = @class.GetProperty(propertyName);
            DescriptionAttribute attribute = property.GetCustomAttribute(typeof(DescriptionAttribute)) as DescriptionAttribute;
            return attribute.Description;
        }

        public static string GetDescription<T>(this Type @class, string methodName)
        {

            var unaryExpression = (UnaryExpression)expression.Body;
            var methodCallExpression = (MethodCallExpression)unaryExpression.Operand;
            var methodInfoExpression = (ConstantExpression)methodCallExpression.Arguments.Last();
            var methodInfo = (MemberInfo)methodInfoExpression.Value;


            var method = @class.GetMethod(methodInfo.Name);
            DescriptionAttribute attribute = method.GetCustomAttribute(typeof(DescriptionAttribute)) as DescriptionAttribute;
            return attribute.Description;
        }
    }
}
