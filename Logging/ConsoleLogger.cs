namespace Logging
{
    public class ConsoleLogger : ILogger
    {
        public void WriteError(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentException("Сообщение не может быть пустым или состоять только из пробелов.", nameof(message));
            }

            Console.WriteLine(message);
        }
    }
}