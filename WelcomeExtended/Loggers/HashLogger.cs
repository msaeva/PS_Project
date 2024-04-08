using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace WelcomeExtended.Loggers
{
    public class HashLogger : ILogger
    {
        private readonly ConcurrentDictionary<int, string> _logMessages;

        private readonly string _name;
        private readonly string _logFilePath;

        public HashLogger(string name, string logFilePath)
        {
            _logMessages = new ConcurrentDictionary<int, string>();
            _name = name;
            _logFilePath = logFilePath;
        }


        public IDisposable? BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        /* public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {

              var massage = formatter(state, exception);

            switch (logLevel)
            {
                case LogLevel.Critical: 
                    Console.ForegroundColor = ConsoleColor.Red; 
                    break;

                case LogLevel.Error:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case LogLevel.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;

            }*/

          /*  Console.WriteLine("- LOGGER - ");

            var messageToBeLogged = new StringBuilder();
            messageToBeLogged.Append($"[{logLevel}]");
            messageToBeLogged.AppendFormat("[{0}]", _name);

            Console.WriteLine(messageToBeLogged);

            Console.WriteLine($"{formatter(state, exception)}");
            Console.WriteLine("- LOGGER - ");

            Console.ResetColor();
        
           _logMessages[eventId.Id] = massage;

           }
          */

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            var message = formatter(state, exception);

            // Console logging
            PrintToConsole(logLevel, eventId, message);

            // File logging
            LogToFile(logLevel, eventId, message);
        }

        private void PrintToConsole(LogLevel logLevel, EventId eventId, string message)
        {
            switch (logLevel)
            {
                case LogLevel.Critical:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case LogLevel.Error:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case LogLevel.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }

            Console.WriteLine("- LOGGER - ");
            Console.WriteLine($"[{logLevel}][{_name}]: {message}");
            Console.WriteLine("- LOGGER - ");

            Console.ResetColor();

            _logMessages[eventId.Id] = message;
        }
        private void LogToFile(LogLevel logLevel, EventId eventId, string message)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(_logFilePath, true))
                {
                    writer.WriteLine($"[{DateTime.Now}] [{logLevel}] [{_name}] Event ID: {eventId.Id} - {message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to log file: {ex.Message}");
            }
        }

        public void PrintAllMessages()
        {
            Console.WriteLine("All logged messages:");
            foreach (var kvp in _logMessages)
            {
                Console.WriteLine($"Event ID: {kvp.Key} - {kvp.Value}");
            }
        }

        public void DeleteMessage(int eventId)
        {
            _logMessages.TryRemove(eventId, out _);
            Console.WriteLine($"Message with Event ID {eventId} deleted.");
        }

     
        public void PrintMessageById(int eventId)
        {
            if (_logMessages.TryGetValue(eventId, out string message))
            {
                Console.WriteLine($"Message for Event ID {eventId}: {message}");
            }
            else
            {
                Console.WriteLine($"Message for Event ID {eventId} not found.");
            }
        }
    }

}
