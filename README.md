# Protected Logger Project
This is a simple C# project demonstrating the use of design patterns like Strategy, Decorator, and Dependency Injection to create a flexible logging system.

# Description
The project showcases how to redesign a logging system using composition over inheritance and adhering to SOLID principles. It involves a Pathfinder class that depends on an ILogger interface. The Pathfinder class has a method Find() that writes logs using its logger.

# Logging Requirements
We need to create five different Pathfinder objects with the following logging behaviors:

* Logs to a file.
* Logs to the console.
* Logs to a file only on Fridays.
* Logs to the console only on Fridays.
* Logs to the console, and logs to a file on Fridays.

# Design Patterns Used
* Strategy Pattern
* Decorator Pattern
* Composite Pattern
* Dependency Injection
