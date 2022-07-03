using System;

namespace OdinLog.Core.Models
{
    public class LogModel
    {
        public string LogId { get; set; }
        public string LogContent { get; set; }
        public string LogMark { get; set; }
        public EnumLogLevel LogLevel { get; set; }
        public Exception LogException { get; set; }
        public EnumLogSaveType[] LogSaveType { get; set; }
        
    }
}

