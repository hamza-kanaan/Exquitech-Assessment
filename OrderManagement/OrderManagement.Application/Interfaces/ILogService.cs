namespace OrderManagement.Application.Interfaces
{
    public interface ILogService<T>
    {
        void LogInfo(string message);
        void LogWarning(string message);
        void LogError(string message, Exception ex);
    }
}