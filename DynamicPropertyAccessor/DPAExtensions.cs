using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DynamicPropertyAccessor
{
    public static class DPAExtensions
    {
        private static IDictionary<Type, IDictionary<string, Tuple<Func<object, object>, Action<object, object>>>> PropertyCache = new Dictionary<Type, IDictionary<string, Tuple<Func<object, object>, Action<object, object>>>>();

        public static void SetProperty(this object obj, string propertyName, object value)
        {
            GetData(obj, propertyName).Item2(obj, value);
        }

        public static T GetProperty<T>(this object obj, string propertyName)
        {
            return (T) GetData(obj, propertyName).Item1(obj);
        }

        public static object GetProperty(this object obj, string propertyName)
        {
            return GetData(obj, propertyName).Item1(obj);
        }

        private static Tuple<Func<object, object>, Action<object, object>> GetData(object obj, string propertyName)
        {
            Type type = obj.GetType();
            Tuple<Func<object, object>, Action<object, object>> propertyAccessors = null;
            IDictionary<string, Tuple<Func<object, object>, Action<object, object>>> subDictionary = null;
            if (PropertyCache.TryGetValue(type, out subDictionary))
            {
                if (!subDictionary.TryGetValue(propertyName, out propertyAccessors))
                {
                    propertyAccessors = Tuple.Create(GetGetAccessor(type, propertyName), GetSetAccessor(type, propertyName));
                    subDictionary[propertyName] = propertyAccessors;
                }
            }
            else
            {
                propertyAccessors = Tuple.Create(GetGetAccessor(type, propertyName), GetSetAccessor(type, propertyName));
                PropertyCache[type] = new Dictionary<string, Tuple<Func<object, object>, Action<object, object>>>(StringComparer.Ordinal) { { propertyName, propertyAccessors } };
            }
            return propertyAccessors;
        }

        public static Action<object, object> GetSetAccessor(Type type, string propertyName)
        {
            ParameterExpression target = Expression.Parameter(typeof(object), "x");
            ParameterExpression value = Expression.Parameter(typeof(object), "value");
            MemberExpression propertyExpression = Expression.Property(Expression.Convert(target, type), propertyName);
            return Expression.Lambda<Action<object, object>>(Expression.Assign(propertyExpression, Expression.Convert(value, propertyExpression.Type)), target, value).Compile();
        }

        public static Func<object, object> GetGetAccessor(Type type, string propertyName)
        {
            ParameterExpression target = Expression.Parameter(typeof(object), "x");
            return Expression.Lambda<Func<object, object>>(Expression.Convert(Expression.Property(Expression.Convert(target, type), propertyName), typeof(object)), target).Compile();
        }
    }
}
