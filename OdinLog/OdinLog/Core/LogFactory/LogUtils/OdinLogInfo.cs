using OdinLog.Core.Models;

namespace OdinLog.Core.LogFactory.LogUtils
{
    public class OdinLogInfo : AbsLogContent
    {
        public OdinLogInfo(EnumLogLevel logLevel, LogConfig config) : base(logLevel, config)
        {
        }

        public override LogResponse WriteLog(LogInfo log)=>WriteLogContent(log);
    }
}

