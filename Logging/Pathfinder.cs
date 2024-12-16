namespace Logging
{
    internal class Pathfinder
    {
        private readonly ILogger _logger;

        public Pathfinder(ILogger logger)
        {
            if (logger == null)
            {
                throw new ArgumentNullException("Логгер не может быть null.", nameof(logger));
            }

            _logger = logger;
        }

        public void Find()
        {
            string message = "Some error message.";

            _logger.WriteError(message);
        }
    }
}