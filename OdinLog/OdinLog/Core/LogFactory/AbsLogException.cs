namespace OdinLog.Core.LogFactory
{
    public abstract class AbsLogException : AbsOdinLogException
    {
        protected AbsLogException(EnumLogLevel logLevel, LogConfig config) : base(logLevel, config)
        {
        }
        private new void WriteLog(string logContent)
        {
        }
    }
}

