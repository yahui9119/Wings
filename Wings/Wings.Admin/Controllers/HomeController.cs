using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wings.Framework.Config;
using Wings.Framework.Plugin;
using Wings.Framework.Plugin.UI;
using Wings.DataObjects;
using Wings.Framework.Caching;
using Wings.Framework.Plugin.Web;
using System.ComponentModel;
using Wings.Framework.Plugin.Contracts;
using Wings.DataObjects.Custom;

namespace Wings.Admin.Controllers
{
    public class HomeController : WingsController
    {
        [DefaultPage]
        [LoginAllowView]
        [Description("[站点主页【首页】]")]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 主页面
        /// </summary>
        /// <returns></returns>
        [LoginAllowView]
        [Description("[站点主页【主页】]")]
        public ActionResult Main()
        {
            return View();
        }
        /// <summary>
        /// 载入菜单 （工具条）
        /// </summary>
        /// <returns></returns>
        [LoginAllowView]
        [Description("[站点主页【获取菜单列表】]")]
        public ActionResult LoadMenus()
        {
            List<Tree> Menus = null;
            List<Permission> permissions = WebSetting.GetPermission();
            if (permissions != null)
            {
                var Root = permissions.Where(p => p._parentId == null || p._parentId == Guid.Empty).OrderBy(p => p.Index);
                if (Root != null)
                {
                    Menus = GetMenus(Root.ToList(), permissions.Where(p=>p.IsMenus==true).ToList());
                }
            }

            return Json(Menus);
        }
        private List<Tree> GetMenus(List<Permission> PList, List<Permission> ALLList)
        {
            List<Tree> trees = new List<Tree>();
            PList.ForEach(
                p =>
                {
                    Tree t = new Tree();
                    t.id = p.ID.ToString();

                    t.iconCls = string.Format("t-icon {0}", p.ICON);
                    //t.state = "open";
                    t.text = p.Name;
                    if (!string.IsNullOrWhiteSpace(p.Url))
                    {
                        t.attributes = new { rel = p.Url };
                    }
                    if (!string.IsNullOrWhiteSpace(p.Controller) && !string.IsNullOrWhiteSpace(p.Action))
                    {
                        t.attributes = new { rel = Url.Action(p.Action, p.Controller) };
                    }
                    var childtree = ALLList.Where(pc => pc._parentId.Equals(p.ID));
                    if (childtree != null && childtree.Count() > 0)
                    {
                        t.children = GetMenus(childtree.ToList(), ALLList);
                    }
                    trees.Add(t);
                }
                );

            return trees;
        }
    }
}
