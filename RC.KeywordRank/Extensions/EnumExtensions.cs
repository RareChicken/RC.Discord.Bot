using System;
using System.Reflection;

namespace RC.KeywordRank.Extensions
{
    public static class EnumExtensions
    {
        /// <summary>
        /// Enum Field에 선언된 Attribute를 제공
        /// </summary>
        /// <typeparam name="T">Attribute</typeparam>
        /// <param name="enum">Enum</param>
        /// <returns>Attribute</returns>
        public static T GetAttribute<T>(this Enum @enum) where T : Attribute
        {
            return @enum.GetType().GetField(@enum.ToString())?.GetCustomAttribute<T>();
        }

        /// <summary>
        /// Attribute의 Property를 제공
        /// </summary>
        /// <typeparam name="TAttribute">AttributeType</typeparam>
        /// <typeparam name="TResult">ResultType</typeparam>
        /// <param name="enum">Enum</param>
        /// <param name="property">Attribute의 Property</param>
        /// <returns>선택된 Property</returns>
        public static TResult GetAttributeProperty<TAttribute, TResult>(this Enum @enum, Func<TAttribute, TResult> property) where TAttribute : Attribute
        {
            if (property == null)
                throw new ArgumentNullException(nameof(property));

            return property.Invoke(@enum.GetAttribute<TAttribute>());
        }
    }
}
