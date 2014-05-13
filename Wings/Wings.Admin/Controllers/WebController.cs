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
    public class WebController : WingsController
    {
        //
        // GET: /Web/

        //
        // GET: /Web/
        [Description("[站点管理【首页】]")]
        public ActionResult Index()
        {

            return View();
        }
        [HttpPost]
        [Description("[站点管理【获取分页表格】]")]
        public ActionResult GetDataGrid(Pagination p)
        {
            DataObjectListWithPagination<WebDTOList> pageData = new DataObjectListWithPagination<WebDTOList>();
            using (ServiceProxy<IWebService> proxy = new ServiceProxy<IWebService>())
            {
                pageData = proxy.Channel.GetWebsByPage(p);
            }
            var result = new DataGrid() { total = pageData.pagination.TotalRecords, rows = pageData.DataObjectList };
            return Json(result);
        }
        [HttpPost]
        [Description("[站点管理【获取树形列表】]")]
        public ActionResult Tree()
        {
            WebDTOList groupdtolist;
            using (ServiceProxy<IWebService> proxy = new ServiceProxy<IWebService>())
            {

                groupdtolist = proxy.Channel.GetAllWebs();

            }
            return Json(groupdtolist.ToTree());
        }
        [HttpPost]
        [Description("[站点管理【添加】]")]
        public ActionResult Add(WebDTO Web)
        {
            Result result = new Result();
            result.message = "添加站点失败";
            using (ServiceProxy<IWebService> proxy = new ServiceProxy<IWebService>())
            {
                Web.CreateDate = DateTime.Now;
                Web.EditDate = DateTime.Now;
                Web.Status = Status.Active;
                Web.Creator = null;
                Web.IsActive = true;
                WebDTOList dtolist = new WebDTOList();
                dtolist.Add(Web);
                try
                {
                    proxy.Channel.CreateWeb(dtolist);
                    result.success = true;
                    result.message = "添加站点成功";
                }
                catch (Exception ex)
                {
                    
                }
            }
            return Json(result);
        }
        [HttpPost]
        [Description("[站点管理【编辑】]")]
        public ActionResult Edit(WebDTO Web)
        {
            Result result = new Result();
            result.message = "修改站点失败";
            using (ServiceProxy<IWebService> proxy = new ServiceProxy<IWebService>())
            {
                Web.EditDate = DateTime.Now;
                WebDTOList dtolist = new WebDTOList();
                dtolist.Add(Web);
                try
                {
                    proxy.Channel.EditWeb(dtolist);
                    result.success = true;
                    result.message = "修改站点成功";
                }
                catch (Exception ex)
                {
                    
                    throw;
                }
            }
            return Json(result);
        }
        [HttpPost]
        [Description("[站点管理【获取单个信息】]")]
        public ActionResult Get(Guid ID)
        {
            WebDTO Webdto = new WebDTO();
            using (ServiceProxy<IWebService> proxy = new ServiceProxy<IWebService>())
            {
                Webdto = proxy.Channel.GetWebByID(ID);
            }
            return Json(Webdto);
        }
        [HttpPost]
        [Description("[站点管理【批量标记删除】]")]
        public ActionResult Delete(IDList idlist)
        {
            Result result = new Result();
            result.message = "删除站点失败";


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
            using (ServiceProxy<IWebService> proxy = new ServiceProxy<IWebService>())
            {
                try
                {

                    proxy.Channel.DeleteWeb(ids);
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
