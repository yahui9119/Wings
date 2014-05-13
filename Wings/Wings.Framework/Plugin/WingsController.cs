using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Wings.Framework.Plugin.UI;
namespace Wings.Framework.Plugin
{
    /// <summary>
    /// mvc基控制器
    /// </summary>
    [PermissionFilter]//权限控制
    [ExceFilter]
    public class WingsController:Controller
    {
    }
}
