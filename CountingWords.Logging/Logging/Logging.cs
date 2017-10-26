using CountingWords.Shared.FluentValidator;
using NLog;
using System;
using System.Collections.Generic;

namespace CountingWords.Log.Logging
{
    /// <summary>
    /// Class responsible to provide methods to save information about the application on archive log.
    /// </summary>
    public static class Logging
    {
        public static void LogInfo(Type type, string text)
        {
            LogManager.GetLogger(type.FullName).Info(text);
        }

        public static void LogWarn(Type type, string text)
        {
            LogManager.GetLogger(type.FullName).Warn(text);
        }

        public static void LogError(Type type, string text)
        {
            LogManager.GetLogger(type.FullName).Error(text);
        }

        public static void LogError(Type type, IEnumerable<Notification> notifications)
        {
            foreach (var notification in notifications)
            {
                LogManager.GetLogger(type.FullName).Error($"Property: {notification.Property} - Message: {notification.Message}");
            }
        }

        public static void LogTrace(Type type, string text)
        {
            LogManager.GetLogger(type.FullName).Trace(text);
        }
    }
}
