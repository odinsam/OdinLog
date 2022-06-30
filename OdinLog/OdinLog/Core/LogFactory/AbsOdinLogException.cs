using OdinLog.Core.Models;

namespace OdinLog.Core.LogFactory
{
    public abstract class AbsOdinLogException : AbsOdinLogFace
    {
        protected AbsOdinLogException(EnumLogLevel logLevel, LogConfig config) : base(logLevel, config)
        {
        }

        public override LogResponse WriteLog(string logContent)=>WriteLogContent(logContent);
    }
}



