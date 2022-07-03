using System;
using OdinLog.Core.Models;

namespace OdinLog.Core
{
    public abstract class AbsOdinLogGenerate : IOdinLog
    {
        protected LogConfig _config;
        public abstract LogModel GenerateLog(EnumLogLevel logLevel,LogInfo log);
    }
}