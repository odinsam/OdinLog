namespace OdinLog.Core.LogFactory
{
    public abstract class AbsOdinLogException : AbsOdinLogFace
    {
        protected AbsOdinLogException(EnumLogLevel logLevel, LogConfig config) : base(logLevel, config)
        {
        }

        public override void WriteLog(string logContent)
        {
            WriteLogContent(logContent);
        }
    }
}



