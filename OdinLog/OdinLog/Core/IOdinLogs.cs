using System;
using OdinLog.Core.LogFactory;
using OdinLog.Core.Models;

namespace OdinLog.Core
{
    public interface IOdinLogs
    {
        LogConfig Config { get; set; }
        
        LogResponse Info(LogInfo log);

        LogResponse Waring(LogInfo log);

        LogResponse Error(ExceptionLog log);
    }
}