using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Reflection;

namespace Eliassen.TestUtilities
{
    /// <inheritdoc/>
    public class GenericTestMethodAttribute : TestMethodAttribute
    {
        /// <inheritdoc/>
        public string? GenericMethodName { get; set; }
        /// <inheritdoc/>
        public int? GenericParameterCount { get; set; }

        /// <inheritdoc/>
        public GenericTestMethodAttribute() { }
        /// <inheritdoc/>
        public GenericTestMethodAttribute(string? displayName) : base(displayName)
        {
        }

        /// <inheritdoc/>
        public override TestResult[] Execute(ITestMethod testMethod) =>
            base.Execute(new GenericTestMethod(testMethod, GenericMethodName, GenericParameterCount));

        /// <inheritdoc/>
        public class GenericTestMethod : ITestMethod
        {
            private readonly ITestMethod _wrap;
            /// <inheritdoc/>
            public GenericTestMethod(ITestMethod wrap)
            {
                _wrap = wrap;
            }

            /// <inheritdoc/>
            public GenericTestMethod(ITestMethod wrap, string? genericMethodName, int? genericParameterCount) : this(wrap)
            {
                GenericMethodName = genericMethodName;
                GenericParameterCount = genericParameterCount;
            }

            /// <inheritdoc/>
            public string? displayName { get; set; }

            /// <inheritdoc/>
            public string TestMethodName => _wrap.TestMethodName;
            /// <inheritdoc/>
            public string TestClassName => _wrap.TestClassName;

            /// <inheritdoc/>
            public Type ReturnType => MethodInfo.ReturnType;
            /// <inheritdoc/>
            public ParameterInfo[] ParameterTypes => MethodInfo.GetParameters();
            /// <inheritdoc/>
            public object?[]? Arguments => _wrap.Arguments?.TakeLast(ParameterTypes.Length).ToArray();

            private MethodInfo? _methodInfo;
            /// <inheritdoc/>
            public MethodInfo MethodInfo => _methodInfo ??=
                 (GenericMethodName ?? _wrap.MethodInfo.Name) switch
                 {
                     string name => _wrap.MethodInfo.DeclaringType?.GetMethods()
                           .Where(mi => mi.IsGenericMethod)
                           .Where(mi => mi.Name == name)
                           .Where(mi => !GenericParameterCount.HasValue || mi.GetGenericArguments().Length == GenericParameterCount.Value)
                           .Select(mi => mi.MakeGenericMethod(_wrap.Arguments?.Select((ta, i) => ta switch
                           {
                               Type t => t,
                               object v => v.GetType(),
                               _ => _wrap.ParameterTypes.Select(p => p.ParameterType).ElementAtOrDefault(i) ?? throw new NotSupportedException()
                           }).Take(mi.GetGenericArguments().Length).ToArray() ?? throw new NotSupportedException()))
                           .FirstOrDefault(),
                     _ => null
                 } ?? throw new NotSupportedException();


            /// <inheritdoc/>
            public string? GenericMethodName { get; }
            /// <inheritdoc/>
            public int? GenericParameterCount { get; }

            /// <inheritdoc/>
            public Attribute[]? GetAllAttributes(bool inherit) =>
                _wrap.GetAllAttributes(inherit);

            /// <inheritdoc/>
            public TAttributeType[] GetAttributes<TAttributeType>(bool inherit) where TAttributeType : Attribute
                => _wrap.GetAttributes<TAttributeType>(inherit);

            /// <inheritdoc/>
            public TestResult Invoke(object[]? arguments)
            {
                var t = _wrap.GetType();
                var p = t.GetProperty("Parent", BindingFlags.NonPublic | BindingFlags.Instance);
                var par = p?.GetValue(_wrap, null);

                //MethodInfo.Invoke()
                throw new NotImplementedException();
            }
        }
    }
}
