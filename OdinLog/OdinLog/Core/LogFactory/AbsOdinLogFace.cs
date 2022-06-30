using System;
using System.IO;
using System.Linq;
using System.Text;
using OdinLog.Core.Models;

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
        public abstract LogResponse WriteLog(string logContent);

        public abstract LogResponse WriteLog(Exception exception);

        protected LogResponse WriteLogContent(string logContent)
        {
            var logInfo = OdinLogHelper.GetInstance(Config).GenerateLog(LogLevel, logContent);
            var logPath = CreateCommonDirectory();
            WriteLog(logPath, logInfo.LogContent);
            return new LogResponse{LogId = logInfo.LogId,LogLevel = LogLevel};
        }

        protected LogResponse WriteLogContent(Exception exception)
        {
            var logInfo = OdinLogHelper.GetInstance(Config).GenerateLog(LogLevel, exception);
            var logPath = CreateCommonDirectory();
            WriteLog(logPath, logInfo.LogContent);
            return new LogResponse{LogId = logInfo.LogId,LogLevel = LogLevel};
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
                    using (File.Create(logFilePath)) ;
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

