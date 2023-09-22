using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;

namespace ProductivityTools.DescriptionValue
{
    public static class DescriptionAttributeExtensions
    {

        /// <summary>
        /// Gets the description specified by the DescriptionAttribute of a property.
        /// </summary>
        /// <typeparam name="TObject">The type containing the property.</typeparam>
        /// <typeparam name="TProperty">The type of the property for which to retrieve the description.</typeparam>
        /// <param name="obj">The instance of the containing class.</param>
        /// <param name="propertyExpression">An expression that identifies the property for which to retrieve the description.</param>
        /// <returns>
        /// The description specified by the DescriptionAttribute of the property,
        /// or string.Empty if the attribute is not found or does not have a Description property.
        /// </returns>
        public static string GetPropertyDescription<TObject, TProperty>(this TObject obj, Expression<Func<TObject, TProperty>> propertyExpression) where TObject : class
        {
            if (propertyExpression == null)
            {
                throw new ArgumentNullException(nameof(propertyExpression));
            }

            PropertyInfo propertyInfo = GetPropertyInfoFromExpression(propertyExpression);

            DescriptionAttribute descriptionAttribute = GetDescriptionAttribute(propertyInfo);

            return descriptionAttribute != null ? descriptionAttribute.Description : string.Empty;
        }

        /// <summary>
        /// Checks if a DescriptionAttribute exists for a property.
        /// </summary>
        /// <typeparam name="TObject">The type containing the property.</typeparam>
        /// <typeparam name="TProperty">The type of the property for which to check the DescriptionAttribute.</typeparam>
        /// <param name="obj">The instance of the containing class.</param>
        /// <param name="propertyExpression">An expression that identifies the property for which to check the DescriptionAttribute.</param>
        /// <returns>
        /// True if the DescriptionAttribute exists for the property; otherwise, false.
        /// </returns>
        public static bool PropertyDescriptionExists<TObject, TProperty>(this TObject obj, Expression<Func<TObject, TProperty>> propertyExpression) where TObject : class
        {
            if (propertyExpression == null)
            {
                throw new ArgumentNullException(nameof(propertyExpression));
            }

            PropertyInfo propertyInfo = GetPropertyInfoFromExpression(propertyExpression);

            return GetDescriptionAttribute(propertyInfo) != null;
        }

        private static PropertyInfo GetPropertyInfoFromExpression<TObject, TProperty>(Expression<Func<TObject, TProperty>> expression)
        {
            MemberExpression memberExpression = GetMemberExpression(expression) ?? throw new ArgumentException("Property expression must be a MemberExpression.", nameof(expression));
  
            PropertyInfo propertyInfo = memberExpression.Member as PropertyInfo ?? throw new ArgumentException("Property expression must represent a property.", nameof(expression));
   
            return propertyInfo;
        }

        private static MemberExpression GetMemberExpression<TObject, TProperty>(Expression<Func<TObject, TProperty>> expression)
        {
            if (expression.Body is MemberExpression memberExpression)
            {
                return memberExpression;
            }

            if (expression.Body is UnaryExpression unaryExpression && unaryExpression.Operand is MemberExpression operandExpression)
            {
                return operandExpression;
            }

            return null;
        }

        private static DescriptionAttribute GetDescriptionAttribute(PropertyInfo propertyInfo) => propertyInfo?.GetCustomAttribute<DescriptionAttribute>();
 
    }

}
