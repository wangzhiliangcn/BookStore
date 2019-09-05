using BookStore.Domain.Interfaces;
using NLog;
using System;

namespace BookStore.Data
{
    public class LoggerAdapter<T> : IAppLogger<T>
    {
        private readonly Logger _logger;

        public LoggerAdapter()
        {
            _logger = LogManager.GetLogger(nameof(T));
        }

        public void Warn(string message, params object[] args)
        {
            _logger.Warn(message, args);
        }

        public void Info(string message, params object[] args)
        {
            _logger.Info(message, args);
        }

        public void Error(string message, params object[] args)
        {
            _logger.Error(message, args);
        }

        public void Error(Type type, string message, params object[] args)
        {
            _logger.Error(type.Name + ":" + message, args);
        }
    }
}
