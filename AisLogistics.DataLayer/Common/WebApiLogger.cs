using System;
using System.Reflection;
using log4net;
using log4net.Appender;
using log4net.Core;
using log4net.Layout;
using log4net.Repository.Hierarchy;

namespace AisLogistics.DataLayer.Common;

public class WebApiLogger
{
    private static bool Configured { get; set; }
    private static ILog _instance;
    private static readonly bool EnableDebugLevel;
    //private static readonly bool EnableLogFieldsValidationException;

    static WebApiLogger()
    {
        Configured = false;
        EnableDebugLevel = false;
        //EnableLogFieldsValidationException = false;
    }

    public static void Configure(string loggerName, string logFileName, bool isRolling)
    {
        if (Configured) return;
        var hierarchy = (Hierarchy)LogManager.GetRepository(Assembly.GetAssembly(typeof(WebApiLogger)));
        var log = LogManager.GetLogger(hierarchy.Name, loggerName);
        PatternLayout patternLayout = new() { ConversionPattern = "%date %-5level - %message%newline" };
        patternLayout.ActivateOptions();
        var l = (Logger)log.Logger;
        if (isRolling)
        {
            RollingFileAppender roller = new()
            {
                LockingModel = new FileAppender.MinimalLock(),
                Layout = patternLayout,
                AppendToFile = true,
                RollingStyle = RollingFileAppender.RollingMode.Size,
                MaxSizeRollBackups = 4,
                MaximumFileSize = "6MB",
                StaticLogFileName = true,
                File = logFileName
            };
            roller.ActivateOptions();
            l.AddAppender(roller);
        }
        else
        {
            FileAppender appender = new()
            {
                LockingModel = new FileAppender.MinimalLock(),
                Layout = patternLayout,
                AppendToFile = true,
                File = logFileName
            };
            appender.ActivateOptions();
            l.AddAppender(appender);
        }
        l.Level = Level.All;
        hierarchy.Configured = true;
        _instance = log;
        Configured = true;
    }

    public static void Info(string message)
    {
        if (message is not null) _instance.Info(message);
    }

    public static void Debug(string message)
    {
        if (EnableDebugLevel) _instance.Debug(message);
    }

    public static void DebugFormat(string message, params object[] args)
    {
        if (EnableDebugLevel) _instance.DebugFormat(message, args);
    }

    public static void LogException(Exception ex)
    {
        _instance.Error(ex.ToString());
    }

    public static void DebugLogException(Exception ex)
    {
        if (EnableDebugLevel)
        {
            LogException(ex);
        }
    }
}