using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelcomeExtended.Loggers
{
    public class AuthenticationLogger
    {
        private string logFilePath;

        public AuthenticationLogger(string filePath)
        {
            logFilePath = filePath;
        }

        public void LogSuccess(string username)
        {
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine($"{DateTime.Now}: User '{username}' logged in successfully.");
            }
        }

        public void LogError(string errorMessage)
        {
            using (StreamWriter errorLog = new StreamWriter(logFilePath, true))
            {
                errorLog.WriteLine($"{DateTime.Now}: Error - {errorMessage}");
            }
        }
    }
}
