namespace Logging
{
    internal class ConditionalLogger : ILogger
    {
        private readonly ILogger _innerLogger;
        private readonly Func<bool> _condition;

        public ConditionalLogger(ILogger innerLogger, Func<bool> condition)
        {
            if (innerLogger == null)
            {
                throw new ArgumentNullException("Логгер не может быть null.", nameof(innerLogger));
            }

            if (condition == null)
            {
                throw new ArgumentNullException("Логгер не может быть null.", nameof(condition));
            }

            _innerLogger = innerLogger;
            _condition = condition;
        }

        public void WriteError(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentException("Сообщение не может быть пустым или состоять только из пробелов.", nameof(message));
            }

            if (_condition())
            {
                _innerLogger.WriteError(message);
            }
        }
    }
}