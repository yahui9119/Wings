using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Wings.Core;
using Wings.Domain.Repositories.EntityFramework;
using Wings.Domain.Repositories.MongoDB;

namespace Wings.SOAService
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            //数据库初始化
            WingsDbContextInitailizer.Initailizer();
            MongoDBBootstrapper.Bootstrap();
            CoreService.Initialize();//映射初始化
            log4net.Config.XmlConfigurator.Configure();//日志初始化
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}