using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.SessionState;

namespace Log4Net
{
    public class LogMessage:IRequiresSessionState
    {
        public LogMessage(string messge)
        {
            this.messge = messge;
       }
        public Guid UserID { get; set; }
        public string UserName { get; set; }

        public Guid WebID { get; set; }
        public string WebName { get; set; }
        private string messge { get; set; }
        public override string ToString()
        {
            return messge;
        }
    }
}
