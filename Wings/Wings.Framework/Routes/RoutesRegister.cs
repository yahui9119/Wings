using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;

namespace Wings.Framework.Routes
{
    public class RoutesRegister
    {
        /// <summary>
        /// 安装路由信息
        /// </summary>
        /// <param name="routes"></param>
        public static void RegisterRoute(IList<System.Web.Routing.Route> routes)
        {
            if (RouteTable.Routes == null)
            {
                return;
            }
            foreach (var item in routes)
            {
                RouteTable.Routes.Add(item);
            }
        }
        /// <summary>
        /// 卸载路由信息
        /// </summary>
        /// <param name="routes"></param>
        public static void DeleteRoute(IList<System.Web.Routing.Route> routes)
        {
           
            if (RouteTable.Routes == null)
            {
                return ;
            }
            bool result;
            foreach (var item in routes)
            {
               result = RouteTable.Routes.Contains(item) ? RouteTable.Routes.Remove(item) : false;
            }
         
        }
    }
}
