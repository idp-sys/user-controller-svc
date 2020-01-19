using Microsoft.Extensions.Logging;
using System;

namespace UserManager.Shared
{
    public class LoggingAdapter<T> : ILogger<T>
    {
        private readonly ILogger adapter;

        public LoggingAdapter(ILoggerFactory factory)
        {
            adapter = factory.CreateLogger<T>();
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return adapter.BeginScope(state);
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return adapter.IsEnabled(logLevel);
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            adapter.Log(logLevel, eventId, state, exception, formatter);
        }
    }
}
