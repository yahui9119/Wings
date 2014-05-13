using log4net.Layout.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log4Net
{
    internal sealed class UserNamePatternConverter : PatternLayoutConverter 
    {
        protected override void Convert(System.IO.TextWriter writer, log4net.Core.LoggingEvent loggingEvent)
        {
            LogMessage logmessage = loggingEvent.MessageObject as LogMessage;
            if(logmessage != null )
            {
                writer.Write(logmessage.UserName);
            }
        }
    }
}
