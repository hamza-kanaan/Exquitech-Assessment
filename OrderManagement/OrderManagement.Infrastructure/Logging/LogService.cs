using OrderManagement.Application.Interfaces;
using Serilog;

namespace OrderManagement.Infrastructure.Logging
{
    public class LogService<T> : ILogService<T>
    {
        private readonly ILogger _logger = Log.ForContext<T>();

        public void LogInfo(string message)
        {
            _logger.Information(message);
        }

        public void LogWarning(string message)
        {
            _logger.Warning(message);
        }

        public void LogError(string message, Exception ex)
        {
            _logger.Error(ex, message);
        }
    }
}