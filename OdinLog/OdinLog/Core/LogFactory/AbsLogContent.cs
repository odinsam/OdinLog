using System;
using OdinLog.Core.Models;

namespace OdinLog.Core.LogFactory
{
    public abstract class AbsLogContent : AbsOdinLogContent
    {
        protected AbsLogContent(EnumLogLevel logLevel, LogConfig config) : base(logLevel, config)
        {
        }

        private new LogResponse WriteLog(Exception exception) => null;
    }
}

