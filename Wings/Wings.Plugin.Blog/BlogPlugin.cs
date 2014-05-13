using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wings.Framework.Plugin;

namespace Wings.Plugin.Blog
{
    public class BlogPlugin : IPlugin
    {
        public string PluginName
        {
            get;
            set;
        }

        public string Describtion
        {
            get;
            set;
        }

        public IList<System.Web.Routing.Route> routes
        {
            get;
            set;
        }
        public BlogPlugin()
        {
            routes = new List<System.Web.Routing.Route>();
            routes.Add(
                new System.Web.Routing.Route(
                "User/Login",
                new System.Web.Routing.RouteValueDictionary(new { controller = "User", Action = "Login" }),
                new System.Web.Mvc.MvcRouteHandler()
                )
                );
            routes.Add(new System.Web.Routing.Route("{controller}/action/{id}/{k}",
                new System.Web.Mvc.MvcRouteHandler()));
        }
    }
}