using System;

namespace OdinLog.Core.Models
{
    public class LogInfo
    {
        public long? LogId { get; set; } = null;
        public string LogContent { get; set; } = "";
        public string LogMark { get; set; } = "";
    }
    
    public class ExceptionLog:LogInfo
    {
        public Exception LogException { get; set; } = null;
    }
}

