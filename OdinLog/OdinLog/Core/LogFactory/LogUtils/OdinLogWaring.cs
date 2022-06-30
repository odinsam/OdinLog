using OdinLog.Core.Models;

namespace OdinLog.Core.LogFactory.LogUtils
{
    public class OdinLogWaring : AbsLogContent
    {
        public OdinLogWaring(EnumLogLevel logLevel, LogConfig config) : base(logLevel, config)
        {
        }

        public override LogResponse WriteLog(string logContent)=>WriteLogContent(logContent);
    }
}
