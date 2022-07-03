using System;
using OdinLog.Core.Models;

namespace OdinLog.Core.LogFactory.LogUtils
{
    public class OdinLogError : AbsLogException
    {
        public OdinLogError(EnumLogLevel logLevel, LogConfig config) : base(logLevel, config)
        {
        }

        public override LogResponse WriteLog(LogInfo log)=>WriteLogContent(log);
    }
}