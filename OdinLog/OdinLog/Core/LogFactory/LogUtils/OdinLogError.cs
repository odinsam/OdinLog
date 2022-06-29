using System;

namespace OdinLog.Core.LogFactory.LogUtils
{
    public class OdinLogError : AbsLogException
    {
        public OdinLogError(EnumLogLevel logLevel, LogConfig config) : base(logLevel, config)
        {
        }

        public override void WriteLog(Exception exception)
        {
            WriteLogContent(exception);
        }
    }
}