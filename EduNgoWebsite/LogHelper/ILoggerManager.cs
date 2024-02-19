namespace EduNgoWebsite.LogHelper
{
    public interface ILoggerManager
    {
        void LogError(string ErrorMessage);
        void LogError(Exception ex, string ErrorMessage);
        void LogTrace(string ErrorMessage);
        void LogDebug(string ErrorMessage);
        void LogInfo(string ErrorMessage);
        void LogErrorCsv(Exception ex, string ErrorMessage);
        void LogErrorDB(Exception ex, string? ErrorMessage = null);
    }
}
