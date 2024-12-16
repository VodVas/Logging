namespace Logging
{
    internal class Program
    {
        static void Main()
        {
            ILogger fileLogger = new FileLogger("log.txt");
            Pathfinder pathfinder = new Pathfinder(fileLogger);

            ILogger consoleLogger = new ConsoleLogger();
            Pathfinder pathfinder1 = new Pathfinder(consoleLogger);

            ILogger fridayFileLogger = new ConditionalLogger(fileLogger, () => DateTime.Now.DayOfWeek == DayOfWeek.Friday);
            Pathfinder pathfinder2 = new Pathfinder(fridayFileLogger);

            ILogger fridayConsoleLogger = new ConditionalLogger(consoleLogger, () => DateTime.Now.DayOfWeek == DayOfWeek.Friday);
            Pathfinder pathfinder3 = new Pathfinder(fridayConsoleLogger);

            ILogger consoleAndFridayFileLogger = new CompositeLogger(new ILogger[] { consoleLogger, new ConditionalLogger(fileLogger, () => DateTime.Now.DayOfWeek == DayOfWeek.Friday) });
            Pathfinder pathfinder4 = new Pathfinder(consoleAndFridayFileLogger);

            pathfinder.Find();
            pathfinder1.Find();
            pathfinder2.Find();
            pathfinder3.Find();
            pathfinder4.Find();

            Console.WriteLine("Логирование завершено.");
        }
    }
}