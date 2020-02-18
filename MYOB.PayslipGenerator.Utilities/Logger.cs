using Newtonsoft.Json;
using System;
using System.Diagnostics;
using log4net;

namespace MYOB.PayslipGenerator.UserInterface
{
    /// <summary>
    /// Logger class to log any information
    /// </summary>
    public static class Logger
    {
        private static readonly ILog logger =
             LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Write a log
        /// </summary>
        /// <param name="log">log to be written</param>
        public static void WriteLog(string log)
        {
            logger.Error(log);
        }

        /// <summary>
        /// Log an exception
        /// </summary>
        /// <param name="exception">exception to be logged</param>
        public static void WriteLog(Exception exception)
        {
            logger.Error(JsonConvert.SerializeObject(exception));
        }
    }
}
