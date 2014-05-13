using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.WebPages;
using Wings.Framework.Caching;
using Wings.Framework.Config;
using Wings.Framework.Plugin.Contracts;
using Wings.Framework.Plugin.Web;

namespace Wings.Framework.Plugin.UI
{
    /// <summary>
    /// 权限拦截
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class PermissionFilterAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// 判断当前用户是否有次访问点的权限
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //权限拦截是否忽略
            bool IsIgnored = false;
            string message = string.Empty;
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }
            //判断当前用户是否是管理员
            var userinfo = WebSetting.GetUser();
            if (userinfo != null && userinfo.ID == WingsConfigurationReader.Instance.WebAdminID)
            {
                message = "当前用户是超级管理员！";
                IsIgnored = true;
            }
            //是否登录和允许匿名访问 即无权限控制
            if (filterContext.ActionDescriptor.IsDefined(typeof(AnonymousAttribute), false))
            {
                message = "匿名使用页面，无权限控制！";
                IsIgnored = true;

            }
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated && !IsIgnored)
            {
                message = "用户未登录，转跳登录！";

                {

                    FormsAuthentication.RedirectToLoginPage();
                }
            }
            else
                //用户已经登录
                if (!IsIgnored)
                {
                    if (filterContext.ActionDescriptor.IsDefined(typeof(LoginAllowViewAttribute), false))
                    {
                        message = "登录即可允许页面！";
                        IsIgnored = true;
                    }
                    else
                    {
                        //读取缓存 是否包含此控制器和访问
                        var permissionsobjs = WebSetting.GetPermission();
                        if (permissionsobjs != null)
                        {
                            List<Permission> permissions = (List<Permission>)permissionsobjs;
                            var path = filterContext.HttpContext.Request.Path.ToLower();
                            string controller = filterContext.RouteData.Values["controller"].ToString();
                            string action = filterContext.RouteData.Values["action"].ToString();
                            var ispost = filterContext.HttpContext.Request.HttpMethod.ToLower() == "post";
                            if (permissions != null && permissions.Count > 0)
                            {

                                var result = permissions.Find(p =>
                                    {
                                        if (p.Action == null || p.Controller == null)
                                        {
                                            return false;
                                        }
                                        else
                                        {
                                            return p.Action.ToLower() == action.ToLower() && p.Controller.ToLower() == controller.ToLower() && p.IsPost == ispost;
                                        }
                                    }
                                    );

                                IsIgnored = result != null;
                            }
                        }
                        message = IsIgnored ? "权限之内页面！" : "不具有权限页面！";
                    }
                }

            //
            if (!IsIgnored)
            {
                filterContext.Result = new JsonResult() { Data = new { success = false, message = "抱歉 您不具有此页面的访问权限,如有疑问请联系管理员！" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            }
            object[] Descriptions = filterContext.ActionDescriptor.GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);
            string OperaName = string.Empty;
            if (Descriptions != null && Descriptions.Count() > 0)
            {
                OperaName = ((System.ComponentModel.DescriptionAttribute)(Descriptions[0])).Description;
            }
            string paras = Newtonsoft.Json.JsonConvert.SerializeObject(filterContext.ActionParameters);
            Log.OperaInstance.SaveMessage(IsIgnored ? 1 : 2, string.Format("权限判断：{0}；参数：{1}；信息：{2}", OperaName, paras, message));
            base.OnActionExecuting(filterContext);
        }
    }
}
