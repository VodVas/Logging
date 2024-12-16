namespace Logging
{
    internal class CompositeLogger : ILogger
    {
        private readonly IEnumerable<ILogger> _loggers;

        public CompositeLogger(IEnumerable<ILogger> loggers)
        {
            if (loggers == null)
            {
                throw new ArgumentNullException("Логгер не может быть null.",nameof(loggers));
            }

            _loggers = loggers;
        }

        public void WriteError(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentException("Сообщение не может быть пустым или состоять только из пробелов.", nameof(message));
            }

            foreach (var logger in _loggers)
            {
                logger.WriteError(message);
            }
        }
    }
}