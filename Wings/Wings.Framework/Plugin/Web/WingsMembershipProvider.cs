using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using Wings.Framework.Communication;

namespace Wings.Framework.Plugin.Web
{
    // 摘要:
    //     定义 ASP.NET 为使用自定义成员资格提供程序提供成员资格服务而实现的协定。
    //集成在插件里面
    public abstract class WingsMembershipProvider : MembershipProvider
    {
        public override bool ValidateUser(string username, string password)
        {
            return false;
            //using (ServiceProxy<IUserService> proxy = new ServiceProxy<IUserService>())
            //{
            //    return proxy.Channel.ValidateUser(username, password);
            //}
        }
    }
}
