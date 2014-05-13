using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wings.Framework.Config;
using Wings.Framework.Plugin.Web;

namespace Wings.Framework
{
    /// <summary>
    /// 日志管理类
    /// </summary>
    public sealed class Log : ILog
    {
        private readonly static Log instance = new Log();
        private readonly static Log operainstance = new Log("Wings.Opera.Logger");
        public static Log Instance
        {
            get
            {
                return instance;
            }
        }
        public static Log OperaInstance
        {
            get
            {
                return operainstance;
            }
        }
        static Log() { }
        public Log()
        {

        }
        public Log(string action)
        {
            log = log4net.LogManager.GetLogger(action);
        }
        private  log4net.ILog log = log4net.LogManager.GetLogger("Wings.Logger");

        public bool IsDebugEnabled
        {
            get { return log.IsDebugEnabled; }
        }

        public bool IsErrorEnabled
        {
            get { return log.IsErrorEnabled; }
        }

        public bool IsFatalEnabled
        {
            get { return log.IsFatalEnabled; }
        }

        public bool IsInfoEnabled
        {
            get { return log.IsInfoEnabled; }
        }

        public bool IsWarnEnabled
        {
            get { return log.IsWarnEnabled; }
        }

        public void Debug(object message)
        {
            if (IsDebugEnabled)
            {
                log.Debug(message);
            }
        }

        public void Debug(object message, Exception exception)
        {
            if (IsDebugEnabled)
            {
                log.Debug(message, exception);
            }
        }

        public void Error(object message)
        {
            if (IsErrorEnabled)
            {
                log.Error(message);
            }
        }

        public void Error(object message, Exception exception)
        {
            if (IsErrorEnabled)
            {
                log.Error(message, exception);
            }
        }

        public void Fatal(object message)
        {
            if (IsFatalEnabled)
            {
                log.Fatal(message);
            }
        }

        public void Fatal(object message, Exception exception)
        {
            if (IsFatalEnabled)
            {
                log.Fatal(message, exception);
            }
        }

        public void Info(object message)
        {
            if (IsInfoEnabled)
            {
                log.Info(message);
            }
        }

        public void Info(object message, Exception exception)
        {
            if (IsInfoEnabled)
            {
                log.Info(message, exception);
            }
        }

        public void Warn(object message)
        {
            if (IsWarnEnabled)
            {
                log.Info(message);
            }
        }

        public void Warn(object message, Exception exception)
        {
            if (IsWarnEnabled)
            {
                log.Info(message, exception);
            }
        }
        /// <summary>
        /// 保存信息
        /// </summary>
        /// <param name="message">需要保存的信息</param>
        /// <param name="level">1 info 2 warm 3 error 4 fatal</param>
        public void SaveMessage(int level, string message, Exception ex = null)
        {
            Log4Net.LogMessage logmessage = new Log4Net.LogMessage(message);
            var user = WebSetting.GetUser();
            logmessage.UserName = System.Web.HttpContext.Current.Session.SessionID;
            logmessage.UserID = Guid.Empty;
            if (user != null)
            {
                logmessage.UserID = user.ID;
                logmessage.UserName = user.Account;
            }
            logmessage.WebID = WingsConfigurationReader.Instance.WebID;
            logmessage.WebName = WingsConfigurationReader.Instance.WebName;
            switch (level)
            {
                case 1:
                    if (IsInfoEnabled)
                    {
                        log.Info(logmessage, ex);
                    };
                    break;

                case 2:
                    if (IsWarnEnabled)
                    {
                        log.Warn(logmessage, ex);
                    };
                    break;
                case 3:
                    if (IsErrorEnabled)
                    {
                        log.Error(logmessage, ex);
                    };
                    break;
                case 4:
                    if (IsFatalEnabled)
                    {
                        log.Fatal(logmessage, ex);
                    };
                    break;
                default:
                    break;
            }
        }
    }
}
