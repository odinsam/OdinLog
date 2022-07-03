using System;
using OdinLog.Core.LogFactory;
using OdinLog.Core.Models;

namespace OdinLog.Core
{
    public class OdinLogs : IOdinLogs
    {
        public LogConfig Config { get; set; }
        public OdinLogs()
        {
        }

        public OdinLogs(LogConfig config)
        {
            this.Config = config;
        }

        public OdinLogs(OdinLogOption opt)
        {
            this.Config = opt.Config;
        }

        public LogResponse Info(LogInfo log)
        {
            return OdinLogFactory.GetOdinLogUtils(EnumLogLevel.Info, Config)?.WriteLog(log);
        }

        public LogResponse Waring(LogInfo log)
        {
            return OdinLogFactory.GetOdinLogUtils(EnumLogLevel.Waring, Config)?.WriteLog(log);
        }

        public LogResponse Error(ExceptionLog log)
        {
            return OdinLogFactory.GetOdinLogUtils(EnumLogLevel.Error, Config)?.WriteLog(log);
        }
    }
}