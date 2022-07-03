using OdinLog.Core.Models;
using SqlSugar;

namespace OdinLog.Core
{
    public class LogConfig
    {
        
        /// <summary>
        /// Log 时间格式 默认: yyyy-MM-dd HH:mm:ss
        /// </summary>
        public string LogTimeFormat { get; set; } = "yyyy-MM-dd HH:mm:ss";

        /// <summary>
        /// Log 分隔符 默认 * 
        /// </summary>
        public string LogSeparator { get; set; } = "*";

        public EnumLogSaveType[] LogSaveType { get; set; } = new EnumLogSaveType[] { EnumLogSaveType.File };

        public DbType DataBaseType { get; set; } = DbType.MySql;
        
        /// <summary>
        /// 连接字符串
        /// </summary>
        public string ConnectionString { get; set; }

    }
}
