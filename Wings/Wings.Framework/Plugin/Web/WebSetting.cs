using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using Wings.Framework.Config;
using Wings.Framework.Plugin.Contracts;

namespace Wings.Framework.Plugin.Web
{
    /// <summary>
    /// 站点设置表述
    /// </summary>
    public class WebSetting
    {
        /// <summary>
        /// 获取所有的访问点
        /// </summary>
        /// <returns></returns>
        public static List<Permission> GetAllAction()
        {
            List<Permission> permissList = new List<Permission>();
            var assembly = WingsConfigurationReader.Instance.WebAssembly;
            if (assembly == null || string.IsNullOrWhiteSpace(assembly))
            {
                return permissList;
            }

            var assemblylist = assembly.Split(',').ToList();
            assemblylist.ForEach(s =>
                {
                    var types = Assembly.Load(s).GetTypes();

                    foreach (var type in types)
                    {
                        if (type.BaseType.Name == "WingsController")//如果是Controller
                        {

                            var actions = type.GetMethods().ToList();
                            if (actions != null)
                            {
                                actions.ForEach(m =>
                                    {
                                        if (m.ReturnType.Name == "ActionResult")//如果是action
                                        {
                                            var permission = new Permission();

                                            permission.Controller = type.Name.Replace("Controller", "");//去除Controller的后缀

                                            permission.Action = m.Name;
                                            object[] actionattrs = m.GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), true);

                                            permission.Description = actionattrs.Length > 0 ? (actionattrs[0] as System.ComponentModel.DescriptionAttribute).Description : string.Empty;
                                            permission.IsPost = m.GetCustomAttributes(typeof(HttpPostAttribute), true).Length > 0;


                                            //permission.Url = new UrlHelper(requestcontext, RouteTable.Routes).Action(permission.Controller, permission.Action);
                                            permissList.Add(permission);
                                        }
                                    });
                            }
                        }
                    }
                });
            return permissList;
        }
        private static string PermissionCacheName = "Permission";
        private static string UserSessionName = "User";
        public static bool IsContainAction(string actionName, string controllerName)
        {
           
            var permission=GetPermission();
            if (permission != null)
            {
 
            }
            return false;
        }
        /// <summary>
        /// 保存用户的权限到缓存中
        /// </summary>
        /// <param name="permission"></param>
        /// <param name="accountid"></param>
        public static void SaveUserPermission(List<Permission> permission,Guid? userid=null)
        {
            UserInfo userinfo = null;
            if (!userid.HasValue)
            {
                userinfo = GetUser();
                if (userinfo == null)
                {
                    return;
                }
            }
            else
            {
                userinfo = new UserInfo() { ID = userid .Value};
            }
            Caching.CacheManager.Instance.Add(PermissionCacheName, userinfo.ID.ToString(), permission);
        }
        public static UserInfo GetUser()
        {
            var usersession = HttpContext.Current.Session[UserSessionName];
            return usersession == null ? null : (UserInfo)usersession;
        }
        /// <summary>
        /// 从缓存中获取此用户的权限
        /// </summary>
        /// <param name="accountid"></param>
        /// <returns></returns>
        public static List<Permission> GetPermission()
        {
            var userinfo = GetUser();
            if (userinfo == null)
            {
                return null;
            }
            var result = Caching.CacheManager.Instance.Get(PermissionCacheName, userinfo.ID.ToString());
            if (result == null)
            {
                return null;
            }
            return (List<Permission>)result;
        }
        /// <summary>
        /// 用户上线
        /// </summary>
        /// <param name="userinfo"></param>
        /// <param name="createPersistentCookie"></param>
        public static void UserOnline(UserInfo userinfo, bool createPersistentCookie)
        {
            FormsAuthentication.RedirectFromLoginPage(userinfo.RealName, createPersistentCookie);
            HttpContext.Current.Session[UserSessionName] = userinfo;
        }
        /// <summary>
        /// 用户下线
        /// </summary>
        public static void UserOffLine()
        {
            FormsAuthentication.SignOut();
            HttpContext.Current.Session[UserSessionName] = null;
            var userinfo = GetUser();
            if (userinfo != null)
            {
                Caching.CacheManager.Instance.Add(PermissionCacheName, userinfo.ID.ToString(),null);
            }
            
            FormsAuthentication.RedirectToLoginPage();

        }
    }
}
