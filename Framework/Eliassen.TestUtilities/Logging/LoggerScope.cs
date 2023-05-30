using System;

namespace Eliassen.TestUtilities.Logging
{
    internal class LoggerScope<TState> : IDisposable
    {
#pragma warning disable IDE0052 // Remove unread private members
        private readonly TState _state;
#pragma warning restore IDE0052 // Remove unread private members

        public LoggerScope(TState state)
        {
            _state = state;
        }

        public void Dispose()
        {
        }
    }
}