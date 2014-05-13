using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wings.Contracts;
using Wings.DataObjects;
using Wings.DataObjects.Custom;
using Wings.Framework.Communication;
using Wings.Framework.Plugin;

namespace Wings.Admin.Controllers
{
    public class GroupController : WingsController
    {
        //
        // GET: /Group/
        [Description("[分组管理【主页】]")]
        public ActionResult Index()
        {

            return View();
        }
        [HttpPost]
        [Description("[分组管理【获取分组列表】]")]
        public ActionResult GetDataGrid(Pagination p)
        {
            GroupDTOList groupdata = new GroupDTOList();
            using (ServiceProxy<IUserService> proxy = new ServiceProxy<IUserService>())
            {
                groupdata = proxy.Channel.GetAllGroups();
            }
            groupdata.ForEach(g => g.ChildGroup = null);
            var result = new DataGrid() { total = groupdata.Count, rows = groupdata };
            return Json(result);
        }
        [HttpPost]
        [Description("[分组管理【获取树形列表】]")]
        public ActionResult Tree()
        {
            GroupDTOList groupdtolist;
            using (ServiceProxy<IUserService> proxy = new ServiceProxy<IUserService>())
            {
               
               groupdtolist= proxy.Channel.GetGroupParentID(null);
               
            }
            return Json(groupdtolist.ToTree());
        }

        [HttpPost]
        [Description("[分组管理【添加】]")]
        public ActionResult Add(GroupDTO groupdto)
        {
            Result result = new Result();
            result.message = "添加部门失败";
            using (ServiceProxy<IUserService> proxy = new ServiceProxy<IUserService>())
            {
                groupdto.CreateDate = DateTime.Now;
                groupdto.EditDate = DateTime.Now;
                groupdto.Creator = null;
                GroupDTOList dtolist = new GroupDTOList();
                dtolist.Add(groupdto);
                proxy.Channel.CreateGroup(dtolist);
                if (!string.IsNullOrEmpty(groupdto.ID))
                {
                    result.success = true;
                    result.message = "添加部门成功";
                }
            }
            return Json(result);
        }
        [HttpPost]
        [Description("[分组管理【编辑】]")]
        public ActionResult Edit(GroupDTO group)
        {
            Result result = new Result();
            result.message = "修改部门失败";
            using (ServiceProxy<IUserService> proxy = new ServiceProxy<IUserService>())
            {
                group.EditDate = DateTime.Now;
                GroupDTOList dtolist = new GroupDTOList();
                dtolist.Add(group);
                proxy.Channel.EditGroup(dtolist);
                if (!string.IsNullOrEmpty(group.ID))
                {
                    result.success = true;
                    result.message = "修改部门成功";
                }
            }
            return Json(result);
        }
        [HttpPost]
        [Description("[分组管理【获取】]")]
        public ActionResult Get(Guid ID)
        {
            GroupDTO groupdto = new GroupDTO();
            using (ServiceProxy<IUserService> proxy = new ServiceProxy<IUserService>())
            {
                groupdto = proxy.Channel.GetGroupByID(ID);
            }
            return Json(groupdto);
        }
        [HttpPost]
        [Description("[分组管理【标记删除】]")]
        public ActionResult Delete(IDList idlist)
        {
            Result result = new Result();
            result.message = "删除部门失败";


            if (idlist == null || idlist.Count == 0)
            {
                result.message = "您提交的数据为空，请重新选择!";
                return Json(result);
            }
            GroupDTOList dtolist = new GroupDTOList();
            idlist.Where(f => !string.IsNullOrEmpty(f)).ToList().ForEach(s =>
            {
                Guid temp = Guid.Empty;
                s.Split(',').ToList().ForEach(g =>
                {

                    if (Guid.TryParse(g, out temp))
                    {
                        dtolist.Add(new GroupDTO() { ID = g }); ;
                    }
                }
                    );
            });
            using (ServiceProxy<IUserService> proxy = new ServiceProxy<IUserService>())
            {
                try
                {

                    proxy.Channel.DeleteGroup(dtolist);
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