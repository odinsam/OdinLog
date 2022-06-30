using OdinLog.Core;
using OdinLog.Core.LogFactory;
using System;
using OdinLog.Core.Models;

namespace OdinLog
{
    public class OdinLogUtils
    {
        public static LogConfig Config { get; set; }
        public static LogResponse Info(string logContent)=>OdinLogFactory.GetOdinLogUtils(EnumLogLevel.Info, Config)?.WriteLog(logContent);

        public static LogResponse Waring(string logContent)=>OdinLogFactory.GetOdinLogUtils(EnumLogLevel.Waring, Config)?.WriteLog(logContent);

        public static LogResponse Error(Exception exception)=>OdinLogFactory.GetOdinLogUtils(EnumLogLevel.Error, Config)?.WriteLog(exception);
    }
}
