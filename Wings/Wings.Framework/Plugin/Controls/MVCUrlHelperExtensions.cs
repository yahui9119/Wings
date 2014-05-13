using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace System.Web.Mvc
{
     // 摘要:
    //   带有权限的
    //     包含用于为应用程序内的 ASP.NET MVC 生成 URL 的方法。
    public static class MVCUrlHelperExtensions
    {
      
        // 摘要:
        //     使用指定的操作名称生成操作方法的完全限定 URL。
        //
        // 参数:
        //   actionName:
        //     操作方法的名称。
        //
        // 返回结果:
        //     操作方法的完全限定 URL。
        public static string ActionWithPermission(this UrlHelper urlhelper, string actionName)
        {
            return urlhelper.Action(actionName);
        }
        //
        // 摘要:
        //     使用指定的操作名称和路由值生成操作方法的完全限定 URL。
        //
        // 参数:
        //   actionName:
        //     操作方法的名称。
        //
        //   routeValues:
        //     一个包含路由参数的对象。通过检查对象的属性，利用反射检索参数。该对象通常是使用对象初始值设定项语法创建的。
        //
        // 返回结果:
        //     操作方法的完全限定 URL。
        public static string ActionWithPermission(this UrlHelper urlhelper, string actionName, object routeValues)
        {
            return urlhelper.Action(actionName, routeValues);
        }
        //
        // 摘要:
        //     为指定的操作名称和路由值生成操作方法的完全限定 URL。
        //
        // 参数:
        //   actionName:
        //     操作方法的名称。
        //
        //   routeValues:
        //     一个包含路由参数的对象。
        //
        // 返回结果:
        //     操作方法的完全限定 URL。
        public static string ActionWithPermission(this UrlHelper urlhelper, string actionName, RouteValueDictionary routeValues)
        {
            return urlhelper.Action(actionName, routeValues);
        }
        //
        // 摘要:
        //     使用指定的操作名称和控制器名称生成操作方法的完全限定 URL。
        //
        // 参数:
        //   actionName:
        //     操作方法的名称。
        //
        //   controllerName:
        //     控制器的名称。
        //
        // 返回结果:
        //     操作方法的完全限定 URL。
        public static string ActionWithPermission(this UrlHelper urlhelper, string actionName, string controllerName)
        {
            return urlhelper.Action(actionName, controllerName);
        }
        //
        // 摘要:
        //     使用指定的操作名称、控制器名称和路由值生成操作方法的完全限定 URL。
        //
        // 参数:
        //   actionName:
        //     操作方法的名称。
        //
        //   controllerName:
        //     控制器的名称。
        //
        //   routeValues:
        //     一个包含路由参数的对象。通过检查对象的属性，利用反射检索参数。该对象通常是使用对象初始值设定项语法创建的。
        //
        // 返回结果:
        //     操作方法的完全限定 URL。
        public static string ActionWithPermission(this UrlHelper urlhelper, string actionName, string controllerName, object routeValues) 
        {
            return urlhelper.Action(actionName, controllerName, routeValues);
        }
        //
        // 摘要:
        //     使用指定的操作名称、控制器名称和路由值生成操作方法的完全限定 URL。
        //
        // 参数:
        //   actionName:
        //     操作方法的名称。
        //
        //   controllerName:
        //     控制器的名称。
        //
        //   routeValues:
        //     一个包含路由参数的对象。
        //
        // 返回结果:
        //     操作方法的完全限定 URL。
        public static string ActionWithPermission(this UrlHelper urlhelper, string actionName, string controllerName, RouteValueDictionary routeValues)
        {
            return urlhelper.Action(actionName, controllerName, routeValues);
        }
        //
        // 摘要:
        //     使用指定的操作名称、控制器名称、路由值和要使用的协议生成操作方法的完全限定 URL。
        //
        // 参数:
        //   actionName:
        //     操作方法的名称。
        //
        //   controllerName:
        //     控制器的名称。
        //
        //   routeValues:
        //     一个包含路由参数的对象。通过检查对象的属性，利用反射检索参数。该对象通常是使用对象初始值设定项语法创建的。
        //
        //   protocol:
        //     URL 协议，如“http”或“https”。
        //
        // 返回结果:
        //     操作方法的完全限定 URL。
        public static string ActionWithPermission(this UrlHelper urlhelper, string actionName, string controllerName, object routeValues, string protocol)
        {
            return urlhelper.Action(actionName, controllerName, routeValues, protocol);
        }
        //
        // 摘要:
        //     使用指定的操作名称、控制器名称、路由值、要使用的协议和主机名生成操作方法的完全限定 URL。
        //
        // 参数:
        //   actionName:
        //     操作方法的名称。
        //
        //   controllerName:
        //     控制器的名称。
        //
        //   routeValues:
        //     一个包含路由参数的对象。
        //
        //   protocol:
        //     URL 协议，如“http”或“https”。
        //
        //   hostName:
        //     URL 的主机名。
        //
        // 返回结果:
        //     操作方法的完全限定 URL。
        public static string ActionWithPermission(this UrlHelper urlhelper, string actionName, string controllerName, RouteValueDictionary routeValues, string protocol, string hostName)
        {
            return urlhelper.Action(actionName, controllerName, routeValues, protocol, hostName);
        }
       
    }
}
