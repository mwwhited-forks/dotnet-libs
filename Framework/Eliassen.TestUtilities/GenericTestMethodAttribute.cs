using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Reflection;

namespace Eliassen.TestUtilities
{
    public class GenericTestMethodAttribute : TestMethodAttribute
    {
        public string? GenericMethodName { get; set; }
        public int? GenericParameterCount { get; set; }

        public GenericTestMethodAttribute() { }
        public GenericTestMethodAttribute(string? displayName) : base(displayName)
        {
        }

        public override TestResult[] Execute(ITestMethod testMethod) =>
            base.Execute(new GenericTestMethod(testMethod, GenericMethodName, GenericParameterCount));

        public class GenericTestMethod : ITestMethod
        {
            private readonly ITestMethod _wrap;
            public GenericTestMethod(ITestMethod wrap)
            {
                _wrap = wrap;
            }

            public GenericTestMethod(ITestMethod wrap, string? genericMethodName, int? genericParameterCount) : this(wrap)
            {
                GenericMethodName = genericMethodName;
                GenericParameterCount = genericParameterCount;
            }

            public string? displayName { get; set; }

            public string TestMethodName => _wrap.TestMethodName;
            public string TestClassName => _wrap.TestClassName;

            public Type ReturnType => MethodInfo.ReturnType;
            public ParameterInfo[] ParameterTypes => MethodInfo.GetParameters();
            public object?[]? Arguments => _wrap.Arguments?.TakeLast(ParameterTypes.Length).ToArray();

            private MethodInfo _methodInfo;
            public MethodInfo MethodInfo => _methodInfo ??=
                 (GenericMethodName ?? _wrap.MethodInfo.Name) switch
                 {
                     string name => _wrap.MethodInfo.DeclaringType?.GetMethods()
                           .Where(mi => mi.IsGenericMethod)
                           .Where(mi => mi.Name == name)
                           .Where(mi => !GenericParameterCount.HasValue || mi.GetGenericArguments().Count() == GenericParameterCount.Value)
                           .Select(mi => mi.MakeGenericMethod(_wrap.Arguments?.Select((ta, i) => ta switch
                           {
                               Type t => t,
                               object v => v.GetType(),
                               _ => _wrap.ParameterTypes.Select(p => p.ParameterType).ElementAtOrDefault(i) ?? throw new NotSupportedException()
                           }).Take(mi.GetGenericArguments().Count()).ToArray() ?? throw new NotSupportedException()))
                           .FirstOrDefault(),
                     _ => null
                 } ?? throw new NotSupportedException();


            public string? GenericMethodName { get; }
            public int? GenericParameterCount { get; }

            public Attribute[]? GetAllAttributes(bool inherit) =>
                _wrap.GetAllAttributes(inherit);

            public TAttributeType[] GetAttributes<TAttributeType>(bool inherit) where TAttributeType : Attribute
                => _wrap.GetAttributes<TAttributeType>(inherit);

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
