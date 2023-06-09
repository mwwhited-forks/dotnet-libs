﻿using Eliassen.System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Eliassen.TestUtilities
{
    public static class TextContextExtensions
    {
        public static TestContext? AddResult(
            this TestContext? context,
            object? value,
            [CallerMemberName] string? caller = default,
            [CallerLineNumber] int callerLine = default,
            [CallerFilePath] string? callerFile = default
            ) =>
            context.AddResult(value, out var _, caller, callerLine, callerFile);

        public static TestContext? AddResult(
            this TestContext? context,
            object? value,
            out string? outFile,
            [CallerMemberName] string? caller = default,
            [CallerLineNumber] int callerLine = default,
            [CallerFilePath] string? callerFile = default
            ) =>
            context.AddResult(value, "", out outFile, caller, callerLine, callerFile);

        public static TestContext? AddResult(
            this TestContext? context,
            object? value,
            string fileName,
            [CallerMemberName] string? caller = default,
            [CallerLineNumber] int callerLine = default,
            [CallerFilePath] string? callerFile = default
            ) =>
            context.AddResult(value, fileName, out _, caller, callerLine, callerFile);

        public static TestContext? AddResult(
            this TestContext? context,
            object? value,
            string? fileName,
            out string? outFile,
            [CallerMemberName] string? caller = default,
            [CallerLineNumber] int callerLine = default,
            [CallerFilePath] string? callerFile = default
            )
        {
            if (context == null)
            {
                outFile = null;
                return default;
            }

            var baseFileName = string.IsNullOrWhiteSpace(fileName) ? value?.GetType()?.Name : Path.GetFileNameWithoutExtension(fileName);
            var baseFileExtension = string.IsNullOrWhiteSpace(fileName) ? "" : Path.GetExtension(fileName);
            var allowChangeExtension = false;
            var timeStamp = DateTime.Now.Ticks;

            if (string.IsNullOrWhiteSpace(baseFileExtension) && (!fileName?.EndsWith('.') ?? true))
            {
                baseFileExtension = ".json";
                allowChangeExtension = true;
            }

            string changeExtension(string inputFileName, string extension) => allowChangeExtension ? Path.ChangeExtension(inputFileName, extension) : inputFileName;
            string cleanFileName(string inputFileName) =>
                "`:<>+&|'\"\b\0\t\r\n"
                    .Concat(Enumerable.Range(1, 30).Select(i => (char)i))
                    .Concat(Path.GetInvalidPathChars())
                    .Concat(Path.GetInvalidFileNameChars())
                    .Distinct()
                    .Aggregate(new StringBuilder(inputFileName), (sb, v) => sb.Replace(v, '_'), sb => sb.ToString());

            var composedFileName = cleanFileName(string.Join('-',
                baseFileName,
                $"{Path.GetFileNameWithoutExtension(callerFile)}_{caller}({callerLine})",
                timeStamp
                ) + baseFileExtension);

            if (value == null)
            {
                outFile = null;
                context.WriteLine($"{composedFileName}: No output");
                return context;
            }

            if (value is byte[] data)
            {
                var file = changeExtension(composedFileName, ".bin");
                AddResultFile(context, file, data, out outFile);
                context.WriteLine($"{file}: Attached");
            }
            else if (value is Stream stream)
            {
                var ms = new MemoryStream();
                stream.CopyTo(ms);
                var file = changeExtension(composedFileName, ".bin");
                AddResultFile(context, file, ms.ToArray(), out outFile);
                context.WriteLine($"{file}: Attached");
            }
            else if (value is IEnumerable<string> lines)
            {
                var file = changeExtension(composedFileName, ".txt");
                AddResultFile(context, file, Encoding.UTF8.GetBytes(string.Join(Environment.NewLine, lines)), out outFile);
                context.WriteLine($"{file}: Attached");
            }
            else if (value is string content)
            {
                var file = changeExtension(composedFileName, ".txt");
                AddResultFile(context, file, Encoding.UTF8.GetBytes(content), out outFile);
                context.WriteLine($"{file}: Attached");
            }
            else if (value != null)
            {
                var file = changeExtension(composedFileName, ".json");
                var json = JsonSerializer.Serialize(value, options: new JsonSerializerOptions
                {
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault,
                    WriteIndented = true,

                });
                AddResultFile(context, file, Encoding.UTF8.GetBytes(json), out outFile);
                context.WriteLine($"{file}: Attached");
            }
            else
            {
                outFile = null;
                context.WriteLine($"{composedFileName}: No output");
            }
            return context;
        }

        public static TestContext AddResultFile(this TestContext context, string fileName, byte[] content) => context.AddResultFile(fileName, content, out var _);
        public static TestContext AddResultFile(this TestContext context, string fileName, byte[] content, out string outFile)
        {
            outFile = Path.Combine(context.TestRunResultsDirectory ?? ".", fileName);
            var dir = Path.GetDirectoryName(outFile);
            if (!string.IsNullOrWhiteSpace(dir) && !Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            File.WriteAllBytes(outFile, content);
            context.AddResultFile(outFile);
            return context;
        }

        public static object? GetTestData(this TestContext context, Type type, string? target = null, IServiceProvider? serviceProvider = null) =>
            context.GetTestDataAsync(type, target, serviceProvider).GetAwaiter().GetResult();

        public static async Task<object?> GetTestDataAsync(this TestContext context, Type type, string? target = null, IServiceProvider? serviceProvider = null)
        {
            if (type == null) return null;

            var typeQuery = from assembly in AppDomain.CurrentDomain.GetAssemblies()
                            from assemblyType in assembly.GetTypes()
                            select assemblyType;
            var testType = typeQuery.FirstOrDefault(t => t.FullName == context.FullyQualifiedTestClassName);

            var targetName = string.IsNullOrWhiteSpace(target) ? context.TestName : target;

            if (string.IsNullOrWhiteSpace(target))
                target = null;

            var possibleResources = target != null ? new[] {
              $"{testType?.Name}_{context.TestName}_{target}" ,
              $"{testType?.Name}_{context.TestName}_{target}.json",
              $"{testType?.Name}_{target}" ,
              $"{testType?.Name}_{target}.json",

              $"{context.TestName}_{target}",
              $"{context.TestName}_{target}.json",
              $"{target}",
              $"{target}.json",
            } : new[]
            {
              $"{testType?.Name}_{context.TestName}",
              $"{testType?.Name}_{context.TestName}.json",
              $"{context.TestName}",
              $"{context.TestName}.json",
            }.Where(i => i != null);

            async Task<string?> getValueAsync()
            {
                foreach (var possible in possibleResources)
                {
                    var result = await testType.GetResourceAsStringAsync(possible);
                    if (!string.IsNullOrWhiteSpace(result))
                        return result;
                }
                return default;
            }
            Stream? getStream()
            {
                foreach (var possible in possibleResources)
                {
                    var result = testType.GetResourceStream(possible);
                    if (result != null)
                        return result;
                }
                return null;
            }
            if (type == typeof(Stream)) return getStream();

            var content = await getValueAsync();

            if (string.IsNullOrWhiteSpace(content)) return default;
            if (type == typeof(string)) return content;
            else if (type == typeof(JToken)) return JToken.Parse(content);
            else if (type == typeof(JObject)) return JObject.Parse(content);
            else if (type == typeof(JArray)) return JArray.Parse(content);

            var services = serviceProvider ??
                new ServiceCollection()
                    .BuildServiceProvider()
                    ;

            var result = JsonSerializer.Deserialize(content, type);
            return result;
        }

        public static async Task<T?> GetTestDataAsync<T>(this TestContext context, string? target = null, IServiceProvider? serviceProvider = null) where T : class =>
            (T?)await context.GetTestDataAsync(typeof(T), target, serviceProvider);

        public static string GetQualifiedTestName(this TestContext context) =>
            $"{context.FullyQualifiedTestClassName}+{context.TestName}";

        public static IEnumerable<string> GetTestRunResultFiles(this TestContext context) =>
            Directory.EnumerateDirectories(context.TestRunResultsDirectory ?? ".");


        public static Type ResolveTestType(this TestContext testContext)
        {
            return resolveType() ?? throw new InvalidOperationException($"Unable to resolve type class for {testContext.FullyQualifiedTestClassName}");

            Type? resolveType()
            {
                var query = from assembly in AppDomain.CurrentDomain.GetAssemblies()
                            from type in assembly.GetTypes()
                            where type.FullName == testContext.FullyQualifiedTestClassName
                            select type;
                return query.FirstOrDefault();
            }
        }

        public static string[] GetResourcePrefixes(this TestContext testContext)
        {
            var testClass = testContext.ResolveTestType();
            var assemblyName = testClass.Assembly.GetName().Name;

            return new[]
            {
                $"{testClass.FullName}.{testContext.TestName}",
                $"{testClass.FullName}.{testContext.TestName}.data",

                $"{testClass.FullName}",
                $"{testClass.FullName}.data",

                $"{testClass.Namespace}",
                $"{testClass.Namespace}.data",

                $"{assemblyName}.data",

                $"{assemblyName}.dataLoading.config_base", //TODO: should probably do something smarter here
                $"{assemblyName}.dataLoading.config_demoSet1",
                $"{assemblyName}.dataLoading.transaction_demoSet1",
            };
        }
    }
}