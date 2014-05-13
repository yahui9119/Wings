using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Wings.Framework.Plugin.UI
{
    /// <summary>
    /// 权限拦截
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class PermissionFilterAttribute:ActionFilterAttribute
    {
        /// <summary>
        /// 判断当前用户是否有次访问点的权限
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            //是否登录和允许匿名访问 即无权限控制
            //读取缓存 是否包含此控制器和访问
            base.OnActionExecuting(filterContext);
        }
    }
}
