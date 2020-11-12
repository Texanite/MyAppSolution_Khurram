using System;
using System.Collections.Generic;
using System.Text;
using App.SharedKernel.Abstractions;
using NLog;
using NLog.Config;

namespace App.SharedKernel.Services
{
    public class LoggerService : ILoggerService
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();

        private const string LoggerName = "NLogLogger";

        public static ILoggerService GetLoggerService()
        {

            ConfigurationItemFactory.Default.LayoutRenderers.RegisterDefinition("default-template", typeof(DefaultLoggingTemplate));

            var logger = LogManager.GetLogger(LoggerName, typeof(LoggerService));

            logger.Info("this is info test soon after RegisterDefination");

            //return logger;
            return null;
        }



        public void LogDebug(string message)
        {
            logger.Debug(message);
        }

        public void LogError(string message)
        {
            logger.Error(message);
        }

        public void LogError(Exception exception)
        {
            logger.Error(exception);
        }

        public void LogInfo(string message)
        {
            logger.Info(message);
        }

        public void LogWarn(string message)
        {
            logger.Warn(message);
        }

    }
}
