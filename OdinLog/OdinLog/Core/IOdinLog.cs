using System;

namespace OdinLog.Core
{
    public interface IOdinLog
    {
        string GenerateLog(EnumLogLevel logLevel, string logContent);
        string GenerateLog(EnumLogLevel logLevel, Exception ex);
    }
}
