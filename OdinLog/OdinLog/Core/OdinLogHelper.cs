using System;
using System.Text;
using Newtonsoft.Json;
using OdinLog.Core.Models;
using OdinLog.OdinUtils;

namespace OdinLog.Core
{
    public class OdinLogHelper : AbsOdinLogGenerate
    {
        
        #region 构造函数
        private static readonly Lazy<OdinLogHelper> Single = new Lazy<OdinLogHelper>(() => new OdinLogHelper());
        private OdinLogHelper()
        {
        }

        /// <summary>
        /// 单例构造函数
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public static OdinLogHelper GetInstance(LogConfig config)
        {
            var odinLogHelper = Single.Value;
            odinLogHelper._config = config ?? new LogConfig();
            return odinLogHelper;
        }
        #endregion

        #region GenerateLog method

        /// <summary>
        /// 生成log
        /// </summary>
        /// <param name="logLevel">log等级</param>
        /// <param name="log">log</param>
        /// <returns></returns>
        public override LogModel GenerateLog(EnumLogLevel logLevel,LogInfo log)
        {
            return GenerateMessageLogTemplate(logLevel, log);
        }
        #endregion

        #region private method
        private LogModel GenerateMessageLogTemplate(EnumLogLevel logLevel, LogInfo log)
        {
            var logid = log.LogId!=null? log.LogId.ToString() : Guid.NewGuid().ToString("N");
            var builder = new StringBuilder();
            var separator = GenerateLogSeparator();
            builder.Append($"【 LogId 】: {logid} \r\n");
            builder.Append($"【 Log Level 】: {logLevel.ToString()} \r\n");
            builder.Append($"【 LogTime 】: {DateTime.Now.ToString(this._config.LogTimeFormat)} \r\n");
            if (log is ExceptionLog)
            {
                builder.Append($"【 Exception Message 】: {(log as ExceptionLog).LogException.Message}\r\n");
                var ex = (log as ExceptionLog).LogException;
                builder.Append($"【 Exception Info 】: \r\n{JsonConvert.SerializeObject(ex).ToJsonFormatString()}\r\n");
            }
            else
            {
                builder.Append($"【 LogContent 】:\r\n{log.LogContent}\r\n");
            }
            builder.Append(separator + "\r\n");
            builder.Append("\r\n");
            return new LogModel{LogId = logid,LogContent = builder.ToString()};
        }
        private string GenerateLogSeparator()
        {
            var c = this._config.LogSeparator[0];
            var separator = this._config.LogSeparator.PadLeft(100, c);
            return separator;
        }
        #endregion
    }
}

