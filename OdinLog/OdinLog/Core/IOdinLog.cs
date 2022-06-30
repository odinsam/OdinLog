using System;
using OdinLog.Core.Models;

namespace OdinLog.Core
{
    public interface IOdinLog
    {
        LogModel GenerateLog(EnumLogLevel logLevel, string logContent);
        LogModel GenerateLog(EnumLogLevel logLevel, Exception ex);
    }
}
