using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wings.Framework.Plugin;
using Wings.DataObjects;
using Wings.Framework.Communication;
using Wings.Contracts;
using Wings.DataObjects.Custom;
using System.ComponentModel;

namespace Wings.Admin.Controllers
{
    /// <summary>
    /// 角色管理
    /// </summary>
    public class RoleController : WingsController
    {
        //
        // GET: /Role/
        [Description("[角色管理【主页】]")]
        public ActionResult Index()
        {

            return View();
        }
        [HttpPost]
        [Description("[角色管理【获取分页表格】]")]
        public ActionResult GetDataGrid(Pagination p)
        {
            DataObjectListWithPagination<RoleDTOList> pageData = new DataObjectListWithPagination<RoleDTOList>();
            using (ServiceProxy<IUserService> proxy = new ServiceProxy<IUserService>())
            {
                pageData = proxy.Channel.GetRolesByPage(p);
            }
            var result = new DataGrid() { total = pageData.pagination.TotalRecords, rows = pageData.DataObjectList };
            return Json(result);
        }
        [HttpPost]
        [Description("[角色管理【获取树形列表】]")]
        public ActionResult Tree()
        {
            RoleDTOList dtolist;
            using (ServiceProxy<IUserService> proxy = new ServiceProxy<IUserService>())
            {

                dtolist = proxy.Channel.GetAllRoles();

            }
            return Json(dtolist.ToTree());
        }
        [HttpPost]
        [Description("[角色管理【添加】]")]
        public ActionResult Add(RoleDTO role)
        {
            Result result = new Result();
            result.message = "添加角色失败";
            using (ServiceProxy<IUserService> proxy = new ServiceProxy<IUserService>())
            {
                role.CreateDate = DateTime.Now;
                role.EditDate = DateTime.Now;
                role.Status = Status.Active;
                role.Creator = null;
                RoleDTOList dtolist = new RoleDTOList();
                dtolist.Add(role);
                proxy.Channel.CreateRole(dtolist);
                if (!string.IsNullOrEmpty(role.ID))
                {
                    result.success = true;
                    result.message = "添加角色成功";
                }
            }
            return Json(result);
        }
        [HttpPost]
        [Description("[角色管理【编辑】]")]
        public ActionResult Edit(RoleDTO role)
        {
            Result result = new Result();
            result.message = "修改角色失败";
            using (ServiceProxy<IUserService> proxy = new ServiceProxy<IUserService>())
            {
                role.EditDate = DateTime.Now;
                RoleDTOList dtolist = new RoleDTOList();
                dtolist.Add(role);
                proxy.Channel.EditRole(dtolist);
                if (!string.IsNullOrEmpty(role.ID))
                {
                    result.success = true;
                    result.message = "修改角色成功";
                }
            }
            return Json(result);
        }
        [HttpPost]
        [Description("[角色管理【获取角色信息】]")]
        public ActionResult Get(Guid ID)
        {
            RoleDTO roledto = new RoleDTO();
            using (ServiceProxy<IUserService> proxy = new ServiceProxy<IUserService>())
            {
                roledto = proxy.Channel.GetRoleByID(ID);
            }
            return Json(roledto);
        }
        [HttpPost]
        [Description("[角色管理【批量标记删除角色】]")]
        public ActionResult Delete(IDList idlist)
        {
            Result result = new Result();
            result.message = "删除角色失败";


            if (idlist == null || idlist.Count == 0)
            {
                result.message = "您提交的数据为空，请重新选择!";
                return Json(result);
            }
            IDList ids = new IDList();

            idlist.Where(f => !string.IsNullOrEmpty(f)).ToList().ForEach(s =>
            {
                Guid temp = Guid.Empty;
                s.Split(',').ToList().ForEach(g =>
                {

                    if (Guid.TryParse(g, out temp))
                    {
                        ids.Add(g);
                    }
                }
                    );
            });
            using (ServiceProxy<IUserService> proxy = new ServiceProxy<IUserService>())
            {
                try
                {

                    proxy.Channel.DeleteRole(ids);
                    result.success = true;
                    result.message = "删除成功";
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
