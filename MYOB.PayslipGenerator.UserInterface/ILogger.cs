using System;
namespace MYOB.PayslipGenerator.UserInterface
{
    /// <summary>
    /// Logger contract
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Write a log
        /// </summary>
        /// <param name="log">log to be written</param>
        void WriteLog(string log);
        
        /// <summary>
        /// Log an exception
        /// </summary>
        /// <param name="exception">exception to be logged</param>
        void WriteLog(Exception exception);
    }
}
