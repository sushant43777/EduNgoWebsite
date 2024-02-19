using EduNgoWebsite.LogHelper;
using NLog;
using System;
namespace EduNgoWebsite.LogHelper
{
    public class LoggerManager : ILoggerManager
    {
        Logger log = NLog.LogManager.GetLogger("ErrorLogFile");
        Logger logErrorWithCSV = NLog.LogManager.GetLogger("logErrorWithCSV");
        Logger logErrorWithSqlService = NLog.LogManager.GetLogger("logErrorWithSqlServer");
        public void LogError(string ErrorMessage)
        {
            log.Error(ErrorMessage);
        }
        public void LogError(Exception ex, string ErrorMessage)
        {
            log.Error(ex, ErrorMessage);
        }
        public void LogErrorCsv(Exception ex, string ErrorMessage)
        {
            logErrorWithCSV.WithProperty("CustomProperty", "Value of custom property");
            logErrorWithCSV.Error(ex, ErrorMessage);
        }
        public void LogErrorDB(Exception ex, string? ErrorMessage = null)
        {
            logErrorWithSqlService.WithProperty("CustomProperty", "Value of custom property for sql server");
            logErrorWithSqlService.Error(ex, ErrorMessage);
        }
        public void LogInfo(string ErrorMessage)
        {
            log.Info(ErrorMessage);
        }
        public void LogDebug(string ErrorMessage)
        {
            log.Debug(ErrorMessage);
        }
        public void LogTrace(string ErrorMessage)
        {
            log.Trace(ErrorMessage);
        }
       
    }
}