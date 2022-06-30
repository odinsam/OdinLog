using OdinLog.Core.Models;

namespace OdinLog.Core.LogFactory
{
    public abstract class AbsLogException : AbsOdinLogException
    {
        protected AbsLogException(EnumLogLevel logLevel, LogConfig config) : base(logLevel, config)
        {
        }

        private new LogResponse WriteLog(string logContent) => null;
    }
}

