using System;

namespace OdinLog.Core.LogFactory
{
    public abstract class AbsLogContent : AbsOdinLogContent
    {
        protected AbsLogContent(EnumLogLevel logLevel, LogConfig config) : base(logLevel, config)
        {
        }
        private new void WriteLog(Exception exception)
        {
        }
    }
}

