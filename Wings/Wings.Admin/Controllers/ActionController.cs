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
using Wings.Framework.Plugin.Contracts;
using Wings.Framework.Plugin.Utils;

namespace Wings.Admin.Controllers
{
    public class ActionController : WingsController
    {
        //
        // GET: /Action/
        [Description("[访问点【主页（未实现）】]")]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Description("[访问点【获取树形列表】]")]
        public ActionResult Tree(string id)
        {
            Guid temp = Guid.Empty;
            if (Guid.TryParse(id, out temp))
            {
                List<Permission> plist = null;
                using (ServiceProxy<IWebService> proxy = new ServiceProxy<IWebService>())
                {
                    try
                    {

                        plist = proxy.Channel.GetAllAction(temp);
                    }
                    catch (Exception ex)
                    {
                    }

                }
                List<Tree> trees = new List<Tree>();
                Func<Permission, Tree> PermissionToTree = p =>
                {
                    Tree t = new Tree();
                    t.id = string.Format("{0}/{1}/{2}", p.Controller, p.Action, p.IsPost);
                    t.text = p.Description;
                    return t;
                };
                if (plist != null)
                {
                    var root = plist.Where(p => p.Action.ToLower() == "index");
                    if (root != null && root.Count() > 0)
                    {
                        root.ToList().ToList().ForEach(p =>
                            {
                                Tree nodetree = PermissionToTree(p);
                                var child = plist.Where(pp => pp.Action.ToLower() != "index" && pp.Controller == p.Controller);
                                if (child != null && child.Count() > 0)
                                {
                                    nodetree.children = new List<DataObjects.Custom.Tree>();
                                    child.ToList().ForEach(pp =>
                                    {
                                        nodetree.children.Add(PermissionToTree(pp));
                                    });
                                }
                                trees.Add(nodetree);
                            }
                            );
                    }

                }
                return Json(trees);
            }
            return Json(null);
        }
    }
}
