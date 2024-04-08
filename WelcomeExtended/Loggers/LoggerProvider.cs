using Microsoft.Extensions.Logging;


namespace WelcomeExtended.Loggers
{
    public class LoggerProvider :ILoggerProvider
    {

        public ILogger CreateLogger(string categoryName)
        {
            return new HashLogger(categoryName, "database.txt");
        }

        public void Dispose()
        {
        }
    }
}
