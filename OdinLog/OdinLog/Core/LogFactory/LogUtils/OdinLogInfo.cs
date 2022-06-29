namespace OdinLog.Core.LogFactory.LogUtils
{
    public class OdinLogInfo : AbsLogContent
    {
        public OdinLogInfo(EnumLogLevel logLevel, LogConfig config) : base(logLevel, config)
        {
        }

        public override void WriteLog(string logContent)
        {
            WriteLogContent(logContent);
        }
    }
}

