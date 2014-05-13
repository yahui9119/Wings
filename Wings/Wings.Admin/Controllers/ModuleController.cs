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
    public class ModuleController : WingsController
    {
        //
        // GET: /Module/
        [Description("[菜单管理【主页】]")]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Description("[菜单管理【获取菜单列表】]")]
        public ActionResult GetDataGrid(Pagination p)
        {
            var webid = Guid.Empty;
            var strwebid = HttpContext.Request.Form["webid"];
            Guid.TryParse(strwebid, out webid);
            ModuleDTOList groupdata = new ModuleDTOList();
            using (ServiceProxy<IWebService> proxy = new ServiceProxy<IWebService>())
            {
                groupdata = proxy.Channel.GetAllWebModules(webid,true);
            }
            groupdata.ForEach(g => g.ChildModule = null);
            var result = new DataGrid() { total = groupdata.Count, rows = groupdata };
            return Json(result);
        }
        [HttpPost]
        [Description("[菜单管理【获取树形列表】]")]
        public ActionResult Tree(string WebId="")
        {
            WebId = Request.QueryString["WebId"];
            Guid webid = Guid.Empty;
            ModuleDTOList ModuleDTOlist = new ModuleDTOList();
            if (Guid.TryParse(WebId, out webid))
            {
                using (ServiceProxy<IWebService> proxy = new ServiceProxy<IWebService>())
                {

                    ModuleDTOlist = proxy.Channel.GetAllWebModules(webid);

                }
 
            }
          
          
            return Json(ModuleDTOlist.ToTree());
        }

        [HttpPost]
        [Description("[菜单管理【添加】]")]
        public ActionResult Add(ModuleDTO ModuleDTO)
        {
            Result result = new Result();
            result.message = "添加部门失败";
            using (ServiceProxy<IWebService> proxy = new ServiceProxy<IWebService>())
            {
                ModuleDTO.CreateDate = DateTime.Now;
                ModuleDTO.EditDate = DateTime.Now;
                ModuleDTO.Creator = null;
                ModuleDTO.IsActive = true;
                proxy.Channel.CreateModule(Wings.Framework.Config.WingsConfigurationReader.Instance.WebID, ModuleDTO);
                if (!string.IsNullOrEmpty(ModuleDTO.ID))
                {
                    result.success = true;
                    result.message = "添加菜单成功";
                }
            }
            return Json(result);
        }
        [HttpPost]
        [Description("[菜单管理【编辑】]")]
        public ActionResult Edit(ModuleDTO dto)
        {
            Result result = new Result();
            result.message = "修改部门失败";
            using (ServiceProxy<IWebService> proxy = new ServiceProxy<IWebService>())
            {
                dto.EditDate = DateTime.Now;
                proxy.Channel.EditModule(dto);
                if (!string.IsNullOrEmpty(dto.ID))
                {
                    result.success = true;
                    result.message = "修改菜单成功";
                }
            }
            return Json(result);
        }
        [HttpPost]
        [Description("[菜单管理【获取】]")]
        public ActionResult Get(Guid ID)
        {
            ModuleDTO ModuleDTO = new ModuleDTO();
            using (ServiceProxy<IWebService> proxy = new ServiceProxy<IWebService>())
            {
                ModuleDTO = proxy.Channel.GetModuleByID(ID);
            }
            return Json(ModuleDTO);
        }
        [HttpPost]
        [Description("[菜单管理【标记删除】]")]
        public ActionResult Delete(IDList idlist)
        {
            Result result = new Result();
            result.message = "删除部门失败";


            if (idlist == null || idlist.Count == 0)
            {
                result.message = "您提交的数据为空，请重新选择!";
                return Json(result);
            }
            IDList dtolist = new IDList();
            idlist.Where(f => !string.IsNullOrEmpty(f)).ToList().ForEach(s =>
            {
                Guid temp = Guid.Empty;
                s.Split(',').ToList().ForEach(g =>
                {

                    if (Guid.TryParse(g, out temp))
                    {
                        dtolist.Add(g.ToString()); ;
                    }
                }
                    );
            });
            using (ServiceProxy<IWebService> proxy = new ServiceProxy<IWebService>())
            {
                try
                {

                    proxy.Channel.DeleteModule(dtolist);
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
