using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace TailorManagementAPI.Utilities
{
    public static class LoggerUtilities
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        static LoggerUtilities()
        {
            string appDirectory = Directory.GetCurrentDirectory();

            // Combine the directory path with the "Logs" folder name
            string logsFolderPath = Path.Combine(appDirectory, "Logs");

            // Create the "Logs" folder if it doesn't exist
            if (!Directory.Exists(logsFolderPath))
            {
                Directory.CreateDirectory(logsFolderPath);
            }
        }
        public static Logger GetLogger()
        {
            return logger;
        }
    }
}