using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WelcomeExtended.Helpers;

namespace WelcomeExtended.Others
{
    public class Delegates
    {
        public static readonly ILogger logger = LoggerHelper.GetLogger("Hello");

        public static void log(string err)
        {
            logger.LogError(err);
        }

        public static void log2(string err)
        {
            Console.WriteLine("- DELEGATES -");
            logger.LogError($"{err}");
            Console.WriteLine("- DELEGATES -");
        }

        public delegate void ActionOnError(string errorMessage);
    }
}
