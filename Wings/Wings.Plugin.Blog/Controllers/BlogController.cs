using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Wings.Plugin.Blog.Controllers
{
    [Wings.Framework.Routes.CustomRouting("~/Views/Blog/Blog")]
    public class BlogController : Controller
    {
        //
        // GET: /Blog/

        public ActionResult Index()
        {
            return View();
        }

    }
}
