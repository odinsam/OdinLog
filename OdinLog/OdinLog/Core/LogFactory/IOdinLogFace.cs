using System;
using OdinLog.Core.Models;

namespace OdinLog.Core.LogFactory
{
    public interface IOdinLogFace
    {
        EnumLogLevel LogLevel { get; set; }
        LogConfig Config { get; set; }
        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="log">log</param>
        LogResponse WriteLog(LogInfo log);
    }
}
