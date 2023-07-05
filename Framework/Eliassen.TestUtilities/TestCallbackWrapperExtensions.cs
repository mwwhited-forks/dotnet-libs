//using Microsoft.Extensions.Logging;
//using System;
//using System.Runtime.CompilerServices;
//using System.Threading.Tasks;

//namespace Eliassen.TestUtilities
//{
//    public static class TestCallbackWrapperExtensions
//    {
//        public static T Invoke<S, T>(
//            this ITestCallbackWrapper callback,
//            S service,
//            object? request = null,
//            ILogger? log = null,
//            Func<T>? @default = null,
//            [CallerMemberName] string? operation = null
//            )
//        {
//            log?.LogInformation($"{{{nameof(operation)}}}", operation);
//            var result = callback.ServiceRequest?.Invoke(typeof(S), service, operation ?? "UNKNOWN", request);
//            if (result is T ret) return ret;
//            else if (@default != null) return @default();
//#pragma warning disable CS8603 // Possible null reference return.
//            return default;
//#pragma warning restore CS8603 // Possible null reference return.
//        }
//        public static void Call<S>(
//           this ITestCallbackWrapper callback,
//           S service,
//           object? request = null,
//           ILogger? log = null,
//           [CallerMemberName] string? operation = null
//           )
//        {
//            log?.LogInformation($"{{{nameof(operation)}}}", operation);
//            _ = callback.ServiceRequest?.Invoke(typeof(S), service, operation ?? "UNKNOWN", request);
//        }

//        public static Task<T> InvokeAsync<S, T>(
//            this ITestCallbackWrapper callback,
//            S service,
//            object? request = null,
//            ILogger? log = null,
//            Func<T>? @default = null,
//            [CallerMemberName] string? operation = null
//            ) => Task.FromResult(callback.Invoke(service, request, log, @default, operation));

//        public static Task CallAsync<S>(
//            this ITestCallbackWrapper callback,
//            S service,
//            object? request = null,
//            ILogger? log = null,
//            [CallerMemberName] string? operation = null
//            )
//        {
//            callback.Call(service, request, log, operation);
//            return Task.FromResult(0);
//        }

//        public static void PublishEvent<S>(
//            this ITestCallbackWrapper callback,
//            string eventName,
//            object? details) => callback.PublishEvent?.Invoke(typeof(S), eventName, details);
//    }
//}
