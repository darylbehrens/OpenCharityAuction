using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenCharityAuction.UnitTests.Models.Services
{
    public class TestLogger : ILogger
    {
        public IDisposable BeginScope<TState>(TState state)
        {
            return (IDisposable)state;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
        }
    }

    public class TestLoggerFactory : ILoggerFactory
    {
        public void AddProvider(ILoggerProvider provider)
        {
            
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new TestLogger();
        }

        public void Dispose()
        {
        }
    }

}
