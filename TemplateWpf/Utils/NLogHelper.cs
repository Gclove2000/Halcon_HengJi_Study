using NLog.Config;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateWpf.Utils
{
    public static class NLogHelper
    {
        private static Logger logger;

        static NLogHelper()
        {
            LogManager.Configuration = new XmlLoggingConfiguration(string.Format("{0}/NLog.config", AppDomain.CurrentDomain.BaseDirectory.ToString()));
            logger = LogManager.GetCurrentClassLogger();
        }

        public static void Debug(string msg)
        {
            Console.WriteLine(msg);
            logger.Debug(msg);
        }

        public static void Info(string msg)
        {
            ConsoleWirte(msg, ConsoleColor.Green);
            logger.Info(msg);

        }

        public static void Error(string msg)
        {
            ConsoleWirte(msg, ConsoleColor.Red);

            logger.Error(msg);
        }

        public static void Warning(string msg)
        {
            ConsoleWirte(msg, ConsoleColor.Yellow);
            logger.Warn(msg);
        }

        public static void ConsoleWirte(string msg, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(msg);
            Console.ResetColor();
        }
    }
}
