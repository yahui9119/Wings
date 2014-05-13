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
    public class GroupPermissionController : WingsController
    {
        //
        // GET: /GroupPermission/
        [Description("分组权限管理【主页】")]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Description("分组权限管理【提交授权】")]
        public ActionResult Authorization(string webid = "", string moduleids = "", string groupid = "")
        {
            Result result = new Result();
            result.message = "授权失败";
            Guid WebId = Guid.Empty;
            Guid GroupID = Guid.Empty;
            if (string.IsNullOrWhiteSpace(webid) || string.IsNullOrWhiteSpace(groupid) || !Guid.TryParse(webid, out WebId) || !Guid.TryParse(groupid, out GroupID))
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

                    proxy.Channel.AssignGroupPermission(GroupID, WebId, modulesid);
                    result.success = true;
                    result.message = "分组授权成功！";
                }
                catch (Exception ex)
                {
                    result.message = ex.Message;
                }

            }
            return Json(result);

        }
        [HttpPost]
        [Description("分组权限管理【获取分组的权限】")]
        public ActionResult GetPermission(string webid = "", string groupid = "")
        {

            Result result = new Result();
            result.message = "获取分组权限失败！";
            List<Guid> ids = null;
            Guid WebId = Guid.Empty;
            Guid GroupID = Guid.Empty;
            if (string.IsNullOrWhiteSpace(webid) || string.IsNullOrWhiteSpace(groupid) || !Guid.TryParse(webid, out WebId) || !Guid.TryParse(groupid, out GroupID))
            {
                return Json(result);
            }
            using (ServiceProxy<IUserService> proxy = new ServiceProxy<IUserService>())
            {
                try
                {
                    ids = proxy.Channel.GetGroupPermissionIDS(GroupID, WebId);
                    result.success = true;
                    result.data = ids;
                    result.message = "获取分组权限成功！";
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
