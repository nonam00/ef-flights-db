using Microsoft.Extensions.Logging;

namespace FlightsDb
{
    public class MyLoggerProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName)
        {
            return new MyLogger();
        }

        public void Dispose() { }

        public class MyLogger : ILogger, IDisposable
        {
            public IDisposable? BeginScope<TState>(TState state) where TState : notnull
            {
                return this;
            }

            public void Dispose() { }

            public bool IsEnabled(LogLevel logLevel) => true;
            public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
            {
                File.AppendAllText("log.dat", formatter(state, exception));
            }
        }
    }
}
