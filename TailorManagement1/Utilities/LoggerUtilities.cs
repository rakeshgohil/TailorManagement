using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TailorManagement1.Utilities
{
    public static class LoggerUtilities
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        static LoggerUtilities()
        {
            string appDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);

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
