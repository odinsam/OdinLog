using System;
using System.Text;
using Newtonsoft.Json;

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
        /// <param name="logContent">log 内容</param>
        /// <returns></returns>
        public override string GenerateLog(EnumLogLevel logLevel, string logContent)
        {
            return GenerateMessageLogTemplate(logLevel, logContent);
        }
        /// <summary>
        /// 生成log
        /// </summary>
        /// <param name="logLevel">log等级</param>
        /// <param name="ex">异常对象</param>
        /// <returns></returns>
        public override string GenerateLog(EnumLogLevel logLevel, Exception ex)
        {
            return GenerateExceptionLogTemplate(logLevel, ex);
        }
        #endregion

        #region private method
        private string GenerateMessageLogTemplate(EnumLogLevel logLevel, string logContent)
        {
            var builder = new StringBuilder();
            var separator = GenerateLogSeparator();
            builder.Append($"【 LogId 】: {Guid.NewGuid().ToString("N")} \r\n");
            builder.Append($"【 Log Level 】: {logLevel.ToString()} \r\n");
            builder.Append($"【 LogTime 】: {DateTime.Now.ToString(this._config.LogTimeFormat)} \r\n");
            builder.Append($"【 LogContent 】:\r\n{logContent}\r\n");
            builder.Append(separator + "\r\n");
            builder.Append("\r\n");
            return builder.ToString();
        }
        private string GenerateExceptionLogTemplate(EnumLogLevel logLevel, Exception ex)
        {
            var builder = new StringBuilder();
            var separator = GenerateLogSeparator();
            builder.Append($"【 LogId 】: {Guid.NewGuid().ToString("N")} \r\n");
            builder.Append($"【 Log Level 】: {logLevel.ToString()} \r\n");
            builder.Append($"【 LogTime 】: {DateTime.Now.ToString(this._config.LogTimeFormat)} \r\n");
            builder.Append($"【 Exception Message 】: {ex.Message}\r\n");
            builder.Append($"【 Exception Info 】: \r\n{JsonConvert.SerializeObject(ex)}\r\n");
            builder.Append(separator + "\r\n");
            builder.Append("\r\n");
            return builder.ToString();
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

