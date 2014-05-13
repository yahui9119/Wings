using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wings.Contracts;
using Wings.DataObjects.Custom;
using Wings.Framework.Communication;
using Wings.Framework.Plugin;

namespace Wings.Admin.Controllers
{
    /// <summary>
    /// 角色权限管理
    /// </summary>
    public class RolePermissionController : WingsController
    {
        //
        // GET: /RolePermission/
        [Description("角色权限管理【主页】")]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Description("角色权限管理【提交授权】")]
        public ActionResult Authorization(string webid = "", string moduleids = "", string roleid = "")
        {
            Result result = new Result();
            result.message = "授权失败";
            Guid WebId = Guid.Empty;
            Guid RoleID = Guid.Empty;
            if (string.IsNullOrWhiteSpace(webid) || string.IsNullOrWhiteSpace(roleid) || !Guid.TryParse(webid, out WebId) || !Guid.TryParse(roleid, out RoleID))
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

                    proxy.Channel.AssignRolePermission(RoleID, WebId, modulesid);
                    result.success = true;
                    result.message = "角色授权成功！";
                }
                catch (Exception ex)
                {
                    result.message = ex.Message;
                }

            }
            return Json(result);

        }
        [HttpPost]
        [Description("角色权限管理【获取角色的权限】")]
        public ActionResult GetPermission(string webid = "", string roleid = "")
        {

            Result result = new Result();
            result.message = "获取角色权限失败！";
            List<Guid> ids = null;
            Guid WebId = Guid.Empty;
            Guid RoleID = Guid.Empty;
            if (string.IsNullOrWhiteSpace(webid) || string.IsNullOrWhiteSpace(roleid) || !Guid.TryParse(webid, out WebId) || !Guid.TryParse(roleid, out RoleID))
            {
                return Json(result);
            }
            using (ServiceProxy<IUserService> proxy = new ServiceProxy<IUserService>())
            {
                try
                {
                    ids = proxy.Channel.GetRolePermissionIDS(RoleID, WebId);
                    result.success = true;
                    result.data = ids;
                    result.message = "获取角色权限成功！";
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

