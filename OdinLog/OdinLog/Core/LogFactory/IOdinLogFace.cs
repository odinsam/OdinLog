using System;

namespace OdinLog.Core.LogFactory
{
    public interface IOdinLogFace
    {
        EnumLogLevel LogLevel { get; set; }
        LogConfig Config { get; set; }
        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="logContent">日志信息</param>
        void WriteLog(string logContent);
        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="exception">异常信息</param>
        void WriteLog(Exception exception);
    }
}
