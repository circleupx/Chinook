using Chinook.Core.Models;
using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;

namespace Chinook.Core
{
    /// <summary> Utility class to build useful expressions that can be compiled into delegates for execution at runtime. </summary>
    internal static class ExpressionFactory
    {
        // internal static Expression LogicalAndExpression(Expression leftExpression, Expression rightExpression)
        // {
        // }

        // internal static Expression LogicalOrExpression(Expression leftExpression, Expression rightExpression)
        // {
        // }

        internal static Expression OperatorExpression(ExpressionType expressionType, Expression leftExpression, Expression rightExpression)
        {
            return expressionType switch
            {
                ExpressionType.Equal => EqualExpression(leftExpression, rightExpression),
                ExpressionType.NotEqual => NotEqualExpression(leftExpression, rightExpression),
                ExpressionType.Call => LikeExpression(leftExpression, rightExpression),
                //ExpressionType.AndAlso => LogicalAndExpression(leftExpression,rightExpression),
                //ExpressionType.OrElse => LogicalOrExpression(leftExpression, rightExpression),
                _ => throw new ArgumentOutOfRangeException(nameof(expressionType), expressionType, $"Expression {expressionType} was not in the defined list of accepted expressions.")
            };
        }

        internal static BinaryExpression EqualExpression(Expression leftExpression, Expression rightExpression)
        {
            return Expression.Equal(leftExpression, rightExpression);
        }

        internal static BinaryExpression NotEqualExpression(Expression leftExpression, Expression rightExpression)
        {
            return Expression.NotEqual(leftExpression, rightExpression);
        }


        internal static UnaryExpression NegateExpression<TObject>(Expression<Func<TObject, bool>> expression)
        {
            return Expression.Not(expression);
        }


        internal static Expression LikeExpression(Expression leftExpression, Expression rightExpression)
        {
            var method = typeof(string).GetMethod("Contains", new[] { typeof(string) }) ?? throw new InvalidOperationException();
            var methodCallExpression = Expression.Call(leftExpression, method, rightExpression);
            return methodCallExpression;
        }

        internal static UnaryExpression ConstantExpression<TObject>(string expressionProperty, string expressionValue)
        {
            var parameterExpression = Expression.Parameter(typeof(TObject));
            var memberExpression = Expression.Property(parameterExpression, expressionProperty);
            var propertyType = ((PropertyInfo)memberExpression.Member).PropertyType;

            var converter = TypeDescriptor.GetConverter(propertyType);
            if (!converter.CanConvertFrom(typeof(string)))
            {
                throw new NotSupportedException($"Failed to convert propertyType {propertyType}.");
            }

            var value = converter.ConvertFromInvariantString(expressionValue);
            var constantExpression = Expression.Constant(value);
            var unaryExpression = Expression.Convert(constantExpression, propertyType);
            return unaryExpression;
        }

        internal static UnaryExpression ConstantExpression(Type type, string expressionProperty, string expressionValue)
        {
            var parameterExpression = Expression.Parameter(type);
            var memberExpression = Expression.Property(parameterExpression, expressionProperty);
            var propertyType = ((PropertyInfo)memberExpression.Member).PropertyType;

            var converter = TypeDescriptor.GetConverter(propertyType);
            if (!converter.CanConvertFrom(typeof(string)))
            {
                throw new NotSupportedException($"Failed to convert propertyType {propertyType}.");
            }

            var value = converter.ConvertFromInvariantString(expressionValue);
            var constantExpression = Expression.Constant(value);
            var unaryExpression = Expression.Convert(constantExpression, propertyType);
            return unaryExpression;
        }

        internal static Expression<Func<TObject, bool>> LikeExpression<TObject>(string propertyName, string propertyValue)
        {
            var parameterExpression = Expression.Parameter(typeof(TObject), "type");
            var memberExpression = Expression.Property(parameterExpression, propertyName);
            var method = typeof(string).GetMethod("Contains", new[] { typeof(string) }) ?? throw new InvalidOperationException();
            var constantExpression = Expression.Constant(propertyValue, typeof(string));
            var methodCallExpression = Expression.Call(memberExpression, method, constantExpression);
            return Expression.Lambda<Func<TObject, bool>>(methodCallExpression, parameterExpression);
        }

        internal static dynamic CreateExpression(FieldNode left, OperatorNode parent, ValueNode right)
        {
            var type = typeof(Album);
            var parameterExpression = ParameterExpression(type);
            var memberExpression = MemberExpression(parameterExpression, left.Value);
            var constantExpression = ConstantExpression<Album>(left.Value, right.Value);
            var completedExpression = OperatorExpression(parent.Value, memberExpression, constantExpression);
            var func = CreateGenericExpressionFunc<Album>(completedExpression, parameterExpression);
            return func;
        }


        internal static Expression<Func<T, bool>> CreateExpression<T>(FieldNode left, OperatorNode parent, ValueNode right)
        {
            var type = typeof(T);
            var parameterExpression = ParameterExpression(type);
            var memberExpression = MemberExpression(parameterExpression, left.Value);
            var constantExpression = ConstantExpression<T>(left.Value, right.Value);

            var completedExpression = OperatorExpression(parent.Value, memberExpression, constantExpression);
            var func = Expression.Lambda<Func<T, bool>>(completedExpression, parameterExpression);
            return func;
        }


        /// <summary>
        /// <see href="https://stackoverflow.com/questions/25793736/how-do-i-create-an-expressionfunc-with-type-parameters-from-a-type-variable"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private static Expression<Func<T, bool>> CreateGenericExpressionFunc<T>(Expression expression, ParameterExpression parameter) 
        {
            var type = typeof(T);
            var delegateType = typeof(Func<,>).MakeGenericType(type, typeof(bool));
            dynamic lambda = Expression.Lambda(delegateType, expression, parameter);
            return lambda;
        }

        private static Expression<Func<T, bool>> ConvertLambda<T>(LambdaExpression originalLambda)
        {
            var type = typeof(T);
            var parameter = Expression.Parameter(type, type.Name);

            var originalType = originalLambda.Parameters[0].Type;
            var convertedParameter = Expression.Convert(parameter, originalType);

            var body = new ParameterReplaceVisitor(originalLambda.Parameters[0], convertedParameter).Visit(originalLambda.Body);

            return Expression.Lambda<Func<T, bool>>(body, parameter);
        }

        private static MemberExpression MemberExpression(ParameterExpression expression, string field)
        {
            return Expression.Property(expression, field);
        }

        private static ParameterExpression ParameterExpression(Type type)
        {
            var parameterExpression = Expression.Parameter(type, type.Name);
            return parameterExpression;
        }
    }
}