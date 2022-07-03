using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using OdinLog.Core.Models;
using SqlSugar;

namespace OdinLog.Core.LogFactory
{
    public abstract class AbsOdinLogFace : IOdinLogFace
    {
        private static object fileLock = new object();
        public EnumLogLevel LogLevel { get; set; }
        public LogConfig Config { get; set; }

        protected AbsOdinLogFace(EnumLogLevel logLevel, LogConfig config)
        {
            LogLevel = logLevel;
            Config = config;
        }
        public abstract LogResponse WriteLog(LogInfo log);

        protected LogResponse WriteLogContent(LogInfo log)
        {
            var logInfo = OdinLogHelper.GetInstance(Config).GenerateLog(LogLevel, log);
            logInfo.LogSaveType = Config.LogSaveType;
            logInfo.LogException = log is ExceptionLog ? (log as ExceptionLog).LogException : null;
            logInfo.LogMark = log.LogMark;
            return WriteLogInfo(logInfo);
        }

        private LogResponse WriteLogInfo(LogModel logInfo)
        {
            if (logInfo.LogSaveType.Contains(EnumLogSaveType.File) || logInfo.LogSaveType.Contains(EnumLogSaveType.All))
            {
                LogWriteFile(logInfo);
            }
            if (logInfo.LogSaveType.Contains(EnumLogSaveType.MySql) || logInfo.LogSaveType.Contains(EnumLogSaveType.SqlServer) || logInfo.LogSaveType.Contains(EnumLogSaveType.All))
            {
                LogWriteDataBase(logInfo);
            }
            return new LogResponse{LogId = logInfo.LogId.ToString(),LogLevel = LogLevel};
        }

        private void LogWriteFile(LogModel logInfo)
        {
            var logPath = CreateCommonDirectory();
            WriteLog(logPath, logInfo.LogContent);
        }

        private ConnectionConfig GenerateConnectionConfig(LogModel logInfo)
        {
            var connectionConfig = new ConnectionConfig()
            {
                ConnectionString = Config.ConnectionString,
                IsAutoCloseConnection = true
            };
            if (logInfo.LogSaveType.Contains(EnumLogSaveType.MySql))
            {
                connectionConfig.DbType = DbType.MySql;
            }
            if (logInfo.LogSaveType.Contains(EnumLogSaveType.SqlServer))
            {
                connectionConfig.DbType = DbType.SqlServer;
            }
            return connectionConfig;
        }
        private void LogWriteDataBase(LogModel logInfo)
        {
            using (var db = new SqlSugarClient(GenerateConnectionConfig(logInfo)))
            {
                StringBuilder sqlStr = new StringBuilder();
                sqlStr.Append("insert into tb_OdinLog");
                sqlStr.Append("(Id,LogLevel,LogContent,ExceptionInfo,Remark,CreateUser,CreateTime,UpdateUser,UpdateTime,IsDelete)");
                sqlStr.Append(" values ");
                sqlStr.Append("(@Id,@LogLevel,@LogContent,@ExceptionInfo,@Remark,@CreateUser,@CreateTime,@UpdateUser,@UpdateTime,0)");
                db.Ado.ExecuteCommand(
                    sqlStr.ToString(),
                    new List<SugarParameter>
                    {
                        new SugarParameter("@Id",logInfo.LogId),
                        new SugarParameter("@LogLevel",logInfo.LogLevel.ToString()),
                        new SugarParameter("@LogContent",logInfo.LogContent.Split("\r\n")[3].Split(":")[1].Trim()),
                        new SugarParameter("@ExceptionInfo",JsonConvert.SerializeObject(logInfo.LogException)),
                        new SugarParameter("@Remark",logInfo.LogMark),
                        new SugarParameter("@CreateUser","OdinLog"),
                        new SugarParameter("@CreateTime",DateTime.Now.ToString(this.Config.LogTimeFormat)),
                        new SugarParameter("@UpdateUser","OdinLog"),
                        new SugarParameter("@UpdateTime",DateTime.Now.ToString(this.Config.LogTimeFormat)),
                        new SugarParameter("@IsDelete",0),
                    });
            }
        }

        private string CreateCommonDirectory()
        {
            var commonDirPath = Path.Combine(AppContext.BaseDirectory, "logs");
            if (!Directory.Exists(commonDirPath)) Directory.CreateDirectory(commonDirPath);
            var levelDirPath = Path.Combine(commonDirPath, LogLevel.ToString());
            if (!Directory.Exists(levelDirPath)) Directory.CreateDirectory(levelDirPath);
            var logTimePath = Path.Combine(levelDirPath, DateTime.Now.ToString("yyyy-MM-dd"));
            if (!Directory.Exists(logTimePath)) Directory.CreateDirectory(logTimePath);
            var logFiles = Directory.GetFiles(logTimePath);
            var logFileName = string.Empty;
            var logFilePath = string.Empty;
            lock (fileLock)
            {
                if (logFiles.Length == 0)
                {
                    logFileName = $"0.txt";
                }
                else
                {
                    var file = logFiles.Last();
                    logFileName = new FileInfo(file).Length > (5 * 1024 * 1024) ? $"{logFiles.Length}.txt" : file;
                }
                logFilePath = Path.Combine(logTimePath, logFileName);
                if (!File.Exists(logFilePath))
                    using (File.Create(logFilePath));
            }
            return logFilePath;
        }

        private void WriteLog(string filePath, string fileContent)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Append, FileAccess.Write))
            {
                using (StreamWriter stw = new StreamWriter(fs, Encoding.UTF8))
                {
                    stw.Write(fileContent);
                    stw.Flush();
                    fs.Flush();
                }
            }
        }
    }
}

