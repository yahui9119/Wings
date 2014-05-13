using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
namespace Wings.Framework.Routes
{
    /// <summary>
    /// 定制 View
    /// </summary>
    public class CustomRouting:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.RouteData.Values["action"] = string.Format("{0}/{1}.cshtml",Folder,filterContext.RouteData.Values["action"].ToString()) ;
            base.OnActionExecuting(filterContext);
        }
        /// <summary>
        /// 顶置此插件的View路径
        /// </summary>
        /// <param name="folder">根目录下Views的路径名</param>
        public CustomRouting(string folder)
        {
            this.Folder = folder;
        }
        /// <summary>
        /// 根目录下Views的路径名
        /// </summary>
        /// <param name="folder"></param>
        public string Folder { get; set; }
    }
}
