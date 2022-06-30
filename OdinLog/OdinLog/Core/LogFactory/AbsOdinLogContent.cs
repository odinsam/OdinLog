using System;
using OdinLog.Core.Models;

namespace OdinLog.Core.LogFactory
{
    public abstract class AbsOdinLogContent : AbsOdinLogFace
    {
        protected AbsOdinLogContent(EnumLogLevel logLevel, LogConfig config) : base(logLevel, config)
        {
        }

        public override LogResponse WriteLog(Exception exception) => null;
    }
}




