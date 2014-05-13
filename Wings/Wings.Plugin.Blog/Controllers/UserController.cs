using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace Wings.Plugin.Blog.Controllers
{
    public class UserController : Controller
    {
        public JsonResult Login()
        {
            return Json(new { success=true,message="hello world"},JsonRequestBehavior.AllowGet);
        }
    }
}
