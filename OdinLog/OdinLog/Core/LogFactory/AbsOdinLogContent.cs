using System;

namespace OdinLog.Core.LogFactory
{
    public abstract class AbsOdinLogContent : AbsOdinLogFace
    {
        protected AbsOdinLogContent(EnumLogLevel logLevel, LogConfig config) : base(logLevel, config)
        {
        }
        public override void WriteLog(Exception exception)
        {
        }
    }
}




