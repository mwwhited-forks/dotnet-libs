using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace Eliassen.TestUtilities
{
    public static class TestContextInterceptionExtensions
    {
        public static object[][] OnExecuteDbDataReader(this TestContext? testContext, object instance, DbCommand command, string? simpleName = null)
        {
            simpleName ??= testContext?.TestName;

            var methodInfo = instance?.GetType()?.GetMethod(nameof(OnExecuteDbDataReader), new[] { typeof(DbCommand), typeof(string) });
            var result = methodInfo?.Invoke(instance, new object[] { command, simpleName });

            testContext?.WriteLine($"==>{nameof(OnExecuteDbDataReader)}:: {command.CommandText} ({string.Join(';', command.Parameters.OfType<DbParameter>().Select(s => s.ParameterName))})");

            return result switch
            {
                object[][] dataset => dataset,
                _ => Array.Empty<object[]>()
            };
        }
        public static int OnExecuteNonQuery(this TestContext testContext, object instance, DbCommand command, string? simpleName = null)
        {
            simpleName ??= testContext.TestName;

            var methodInfo = instance?.GetType()?.GetMethod(nameof(OnExecuteNonQuery), new[] { typeof(DbCommand), typeof(string) });
            var result = methodInfo?.Invoke(instance, new object[] { command, simpleName });

            testContext?.WriteLine($"==>{nameof(OnExecuteNonQuery)}:: {command.CommandText} ({string.Join(';', command.Parameters.OfType<DbParameter>().Select(s => s.ParameterName))})");

            return result switch
            {
                int dataset => dataset,
                _ => -1
            };
        }
        public static object? OnExecuteScalar(this TestContext testContext, object instance, DbCommand command, string? simpleName = null)
        {
            simpleName ??= testContext.TestName;

            var methodInfo = instance?.GetType()?.GetMethod(nameof(OnExecuteScalar), new[] { typeof(DbCommand), typeof(string) });
            var result = methodInfo?.Invoke(instance, new object[] { command, simpleName });

            testContext?.WriteLine($"==>{nameof(OnExecuteScalar)}:: {command.CommandText} ({string.Join(';', command.Parameters.OfType<DbParameter>().Select(s => s.ParameterName))})");

            return result;
        }


        public static object? ServiceInterception(this TestContext testContext, string simpleName, Type type, object service, string operation, object request)
        {
            var resourceName = $"{simpleName}-Request-{type.Name.Split('`').FirstOrDefault()}_{operation}.json";
            testContext?.WriteLine($"{nameof(ServiceInterception)}::{service} ({resourceName})");

            var requestType = request switch
            {
                null => Type.EmptyTypes,
                _ when request.GetType().IsGenericType &&
                       request.GetType().Name.StartsWith("ValueTuple`") => request.GetType().GetGenericArguments(),
                _ => new[] { request.GetType() }
            };

            var methodInfo = type.GetMethod(operation, requestType) ??
                type.GetMethods().FirstOrDefault(m => m.Name == operation) ??
                type.GetInterfaces().SelectMany(m => m.GetMethods()).FirstOrDefault(m => m.Name == operation)
                ;
            if (methodInfo != null)
            {
                var returnType = methodInfo.ReturnType;
                if (returnType != null && returnType != typeof(void) && returnType != typeof(Task))
                {
                    if (typeof(Task).IsAssignableFrom(returnType))
                    {
                        //unwrap Task Result
                        returnType = returnType.GetGenericArguments()[0];
                    }

                    var result = testContext.GetTestData(returnType, resourceName, null);
                    if (result == null)
                    {
                        testContext?.WriteLine($"Create \"{resourceName}\" of type \"{returnType}\" to replace this response");
                    }

                    return result;
                }
            }

            return null;
        }
    }
}
