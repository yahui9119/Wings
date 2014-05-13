using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wings.Contracts;
using Wings.DataObjects.Custom;
using Wings.Framework.Communication;
using Wings.Framework.Plugin;

namespace Wings.Admin.Controllers
{
    public class UserPermissionController : WingsController
    {
        //
        // GET: /UserPermissionAssign/
        [Description("[用户授权【主页】]")]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Description("用户添加授权【提交授权】")]
        public ActionResult AuthorizationAllow(string webid = "", string moduleids = "", string userid = "")
        {
            Result result = new Result();
            result.message = "授权失败";
            Guid WebId = Guid.Empty;
            Guid UserID = Guid.Empty;
            if (string.IsNullOrWhiteSpace(webid) || string.IsNullOrWhiteSpace(userid) || !Guid.TryParse(webid, out WebId) || !Guid.TryParse(userid, out UserID))
            {
                return Json(result);
            }
            List<Guid> modulesid = new List<Guid>();
            moduleids.Split(',').ToList().ForEach(s =>
            {
                Guid temp = Guid.Empty;
                if (Guid.TryParse(s, out temp))
                {
                    modulesid.Add(temp);
                }
            });
            using (ServiceProxy<IUserService> proxy = new ServiceProxy<IUserService>())
            {
                try
                {

                    proxy.Channel.AssignUserPermission(UserID,WebId, modulesid, false);
                    result.success = true;
                    result.message = "用户授权成功！";
                }
                catch (Exception ex)
                {
                    result.message = ex.Message;
                }

            }
            return Json(result);

        }
        [HttpPost]
        [Description("用户添加授权【获取用户的权限】")]
        public ActionResult GetPermissionAllow(string webid = "", string userid = "")
        {

            Result result = new Result();
            result.message = "获取用户权限失败！";
            List<Guid> ids = null;
            Guid WebId = Guid.Empty;
            Guid UserID = Guid.Empty;
            if (string.IsNullOrWhiteSpace(webid) || string.IsNullOrWhiteSpace(userid) || !Guid.TryParse(webid, out WebId) || !Guid.TryParse(userid, out UserID))
            {
                return Json(result);
            }
            using (ServiceProxy<IUserService> proxy = new ServiceProxy<IUserService>())
            {
                try
                {
                    ids = proxy.Channel.GetUserPermission(UserID, WebId,false);
                    result.success = true;
                    result.data = ids;
                    result.message = "获取用户权限成功！";
                }
                catch (Exception ex)
                {
                    result.message = ex.Message;
                }

            }
            return Json(result);
        }

        [HttpPost]
        [Description("用户禁用授权【提交授权】")]
        public ActionResult AuthorizationBan(string webid = "", string moduleids = "", string userid = "")
        {
            Result result = new Result();
            result.message = "禁用授权失败";
            Guid WebId = Guid.Empty;
            Guid UserID = Guid.Empty;
            if (string.IsNullOrWhiteSpace(webid) || string.IsNullOrWhiteSpace(userid) || !Guid.TryParse(webid, out WebId) || !Guid.TryParse(userid, out UserID))
            {
                return Json(result);
            }
            List<Guid> modulesid = new List<Guid>();
            moduleids.Split(',').ToList().ForEach(s =>
            {
                Guid temp = Guid.Empty;
                if (Guid.TryParse(s, out temp))
                {
                    modulesid.Add(temp);
                }
            });
            using (ServiceProxy<IUserService> proxy = new ServiceProxy<IUserService>())
            {
                try
                {

                    proxy.Channel.AssignUserPermission(UserID, WebId, modulesid, true);
                    result.success = true;
                    result.message = "禁用用户权限成功！";
                }
                catch (Exception ex)
                {
                    result.message = ex.Message;
                }

            }
            return Json(result);

        }
        [HttpPost]
        [Description("用户禁用授权【获取用户的权限】")]
        public ActionResult GetPermissionBan(string webid = "", string userid = "")
        {

            Result result = new Result();
            result.message = "获取用户权限失败！";
            List<Guid> ids = null;
            Guid WebId = Guid.Empty;
            Guid UserID = Guid.Empty;
            if (string.IsNullOrWhiteSpace(webid) || string.IsNullOrWhiteSpace(userid) || !Guid.TryParse(webid, out WebId) || !Guid.TryParse(userid, out UserID))
            {
                return Json(result);
            }
            using (ServiceProxy<IUserService> proxy = new ServiceProxy<IUserService>())
            {
                try
                {
                    ids = proxy.Channel.GetUserPermission(UserID, WebId, true);
                    result.success = true;
                    result.data = ids;
                    result.message = "获取用户权限成功！";
                }
                catch (Exception ex)
                {
                    result.message = ex.Message;
                }

            }
            return Json(result);
        }
    }
}
