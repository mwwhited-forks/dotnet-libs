using System;
using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Eliassen.TestUtilities.Logging
{
    /// <inheritdoc/>
    public class TestLogger : ILogger
    {
        /// <inheritdoc/>
        protected readonly TestContext _context;
        /// <inheritdoc/>
        protected readonly string? _category;

        /// <inheritdoc/>
        public TestLogger(
            TestContext testContext,
            string? category = null
            )
        {
            _context = testContext;
            _category = string.IsNullOrWhiteSpace(category) ? null : category;
        }

        /// <inheritdoc/>
        [ActivatorUtilitiesConstructor]
        public TestLogger(
            ITestContextWrapper contextWrapper,
            string? category = null
            )
        {
            _context = contextWrapper.Context;
            _category = string.IsNullOrWhiteSpace(category) ? null : category;
        }

        /// <inheritdoc/>
        public virtual IDisposable BeginScope<TState>(TState state) => new LoggerScope<TState>(state);

        /// <inheritdoc/>
        public virtual bool IsEnabled(LogLevel logLevel) => true;

        /// <inheritdoc/>
        public virtual void Log<TState>(
            LogLevel logLevel, 
            EventId eventId, 
            TState state,
            Exception? exception,
            Func<TState, Exception?, string> formatter
            )
        {
            void WriteMessage(string message)
            {
                if (_context == null)
                {
                    Debug.WriteLine(message);
                }
                else
                {
                    _context.WriteLine(message);
                }
            }

            if (formatter != null)
            {
                WriteMessage($@"{_category}-LOG>{logLevel}({eventId}): {formatter(state, exception)}");
            }
            else
            {
                WriteMessage($@"{_category}-LOG>{logLevel}({eventId}): {state}");
                if (exception != null)
                {
                    WriteMessage($@"{_category}-ERROR>{logLevel}({eventId}): {exception}");
                }
            }
        }
    }

    /// <inheritdoc/>
    public class TestLogger<T> : TestLogger, ILogger<T>
    {
        /// <inheritdoc/>
        public TestLogger(
            TestContext testContext
            ) : base(testContext, typeof(T).FullName)
        {
        }
        /// <inheritdoc/>
        public TestLogger(
            ITestContextWrapper contextWrapper
            ) : base(contextWrapper, typeof(T).FullName)
        {
        }
    }
}