using OdinLog.Core;
using OdinLog.Core.LogFactory;
using System;

namespace OdinLog
{
    public class OdinLogUtils
    {
        public static LogConfig Config { get; set; }
        public static void Info(string logContent)
        {
            OdinLogFactory.GetOdinLogUtils(EnumLogLevel.Info, Config)?.WriteLog(logContent);
        }

        public static void Waring(string logContent)
        {
            OdinLogFactory.GetOdinLogUtils(EnumLogLevel.Waring, Config)?.WriteLog(logContent);
        }

        public static void Error(Exception exception)
        {
            OdinLogFactory.GetOdinLogUtils(EnumLogLevel.Error, Config)?.WriteLog(exception);
        }
    }
}
