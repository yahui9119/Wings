using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wings.Framework.Plugin.UI
{
    /// <summary>
    /// 表示该方法 登录的用户都可以访问
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class LoginAllowViewAttribute : Attribute
    {
    }
}
