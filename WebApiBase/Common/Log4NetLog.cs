using System;
using System.IO;
using log4net;
using log4net.Appender;

public class Log4NetLog
{
    private static string filepath = AppDomain.CurrentDomain.BaseDirectory + @"SysLog\";

    private static readonly log4net.ILog logComm = log4net.LogManager.GetLogger("Log4NetLog");

    static Log4NetLog()
    {
        log4net.Config.XmlConfigurator.Configure(new FileInfo("log4net.config"));

        if (!Directory.Exists(filepath))
        {
            Directory.CreateDirectory(filepath);
        }
    }

    /// <summary>
    /// 输出系统日志
    /// </summary>
    /// <param name="msg">信息内容</param>
    /// <param name="source">信息来源</param>
    private static void WriteLog(string msg, bool isWrite, Action<object> action)
    {
        if (isWrite)
        {
            string filename = "日志信息" + DateTime.Now.ToString("yyyyMMdd_HH") + ".log";
            var repository = LogManager.GetRepository();

            #region MyRegion

            var appenders = repository.GetAppenders();

            if (appenders.Length > 0)
            {
                RollingFileAppender targetApder = null;
                foreach (var Apder in appenders)
                {
                    if (Apder.Name == "Log4NetLog")
                    {
                        targetApder = Apder as RollingFileAppender;
                        break;
                    }
                }

                if (targetApder.Name == "Log4NetLog") //如果是文件输出类型日志，则更改输出路径
                {
                    if (targetApder != null)
                    {
                        if (!targetApder.File.Contains(filename))
                        {
                            targetApder.File = @"SysLog\" + filename;
                            targetApder.ActivateOptions();
                        }
                    }
                }
            }

            #endregion

            action(msg);
            //logComm.Error(msg + "\n");
        }

        Console.WriteLine(filepath);
    }

    public static void WriteError(string msg, bool isWrite)
    {
        WriteLog(msg, isWrite, logComm.Error);
    }

    public static void WriteInfo(string msg, bool isWrite)
    {
        WriteLog(msg, isWrite, logComm.Info);
    }

    public static void WriteWarn(string msg, bool isWrite)
    {
        WriteLog(msg, isWrite, logComm.Warn);
    }
}