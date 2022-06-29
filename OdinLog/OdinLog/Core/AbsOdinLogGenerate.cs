using System;

namespace OdinLog.Core
{
    public abstract class AbsOdinLogGenerate : IOdinLog
    {
        protected LogConfig _config;
        public abstract string GenerateLog(EnumLogLevel logLevel,string logContent);
        public abstract string GenerateLog(EnumLogLevel logLevel,Exception ex);
    }
}