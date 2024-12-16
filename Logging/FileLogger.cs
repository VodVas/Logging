namespace Logging
{
    internal class FileLogger : ILogger
    {
        private readonly string _filePath;

        public FileLogger(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentException("Путь к файлу не может быть пустым или состоять только из пробелов.", nameof(filePath));
            }

            _filePath = filePath;
        }

        public void WriteError(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentException("Сообщение не может быть пустым или состоять только из пробелов.", nameof(message));
            }

            try
            {
                File.AppendAllText(_filePath, message + Environment.NewLine);
            }
            catch (UnauthorizedAccessException exception)
            {
                Console.WriteLine($"Ошибка доступа: {exception.Message}");
            }
            catch (DirectoryNotFoundException exception)
            {
                Console.WriteLine($"Директория не найдена: {exception.Message}");
            }
            catch (PathTooLongException exception)
            {
                Console.WriteLine($"Слишком длинный путь: {exception.Message}");
            }
            catch (IOException exception)
            {
                Console.WriteLine($"Ошибка ввода-вывода: {exception.Message}");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Произошла непредвиденная ошибка: {exception.Message}");
            }
        }
    }
}