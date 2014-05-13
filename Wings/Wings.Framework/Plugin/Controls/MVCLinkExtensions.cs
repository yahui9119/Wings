using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace System.Web.Mvc
{
    public static class MVCLinkExtensions
    {
        //
        // 摘要:
        //     返回包含指定操作的虚拟路径的定位点元素（a 元素）。
        //
        // 参数:
        //   htmlHelper:
        //     此方法扩展的 HTML 帮助器实例。
        //
        //   linkText:
        //     定位点元素的内部文本。
        //
        //   actionName:
        //     操作的名称。
        //
        //   controllerName:
        //     控制器的名称。
        //
        // 返回结果:
        //     一个定位点元素（a 元素）。
        //
        // 异常:
        //   System.ArgumentException:
        //     linkText 参数为 null 或为空。
        public static MvcHtmlString ActionLinkWithPermission(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName)
        {
            return htmlHelper.ActionLink(linkText, actionName, controllerName);
        }
        //
        // 摘要:
        //     返回包含指定操作的虚拟路径的定位点元素（a 元素）。
        //
        // 参数:
        //   htmlHelper:
        //     此方法扩展的 HTML 帮助器实例。
        //
        //   linkText:
        //     定位点元素的内部文本。
        //
        //   actionName:
        //     操作的名称。
        //
        //   controllerName:
        //     控制器的名称。
        //
        //   routeValues:
        //     一个包含路由参数的对象。通过检查对象的属性，利用反射检索参数。该对象通常是使用对象初始值设定项语法创建的。
        //
        //   htmlAttributes:
        //     一个对象，其中包含要为该元素设置的 HTML 特性。
        //
        // 返回结果:
        //     一个定位点元素（a 元素）。
        //
        // 异常:
        //   System.ArgumentException:
        //     linkText 参数为 null 或为空。
        public static MvcHtmlString ActionLinkWithPermission(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, object routeValues, object htmlAttributes)
        {


            return htmlHelper.ActionLink(linkText, actionName,controllerName, routeValues, htmlAttributes);
        }
        //
        // 摘要:
        //     返回包含指定操作的虚拟路径的定位点元素（a 元素）。
        //
        // 参数:
        //   htmlHelper:
        //     此方法扩展的 HTML 帮助器实例。
        //
        //   linkText:
        //     定位点元素的内部文本。
        //
        //   actionName:
        //     操作的名称。
        //
        //   controllerName:
        //     控制器的名称。
        //
        //   routeValues:
        //     一个包含路由参数的对象。
        //
        //   htmlAttributes:
        //     一个对象，其中包含要为该元素设置的 HTML 特性。
        //
        // 返回结果:
        //     一个定位点元素（a 元素）。
        //
        // 异常:
        //   System.ArgumentException:
        //     linkText 参数为 null 或为空。
        public static MvcHtmlString ActionLinkWithPermission(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes)
        {
            return htmlHelper.ActionLink(linkText, actionName, controllerName, routeValues, htmlAttributes);
        }
        //
        // 摘要:
        //     返回包含指定操作的虚拟路径的定位点元素（a 元素）。
        //
        // 参数:
        //   htmlHelper:
        //     此方法扩展的 HTML 帮助器实例。
        //
        //   linkText:
        //     定位点元素的内部文本。
        //
        //   actionName:
        //     操作的名称。
        //
        //   controllerName:
        //     控制器的名称。
        //
        //   protocol:
        //     URL 协议，如“http”或“https”。
        //
        //   hostName:
        //     URL 的主机名。
        //
        //   fragment:
        //     URL 片段名称（定位点名称）。
        //
        //   routeValues:
        //     一个包含路由参数的对象。通过检查对象的属性，利用反射检索参数。该对象通常是使用对象初始值设定项语法创建的。
        //
        //   htmlAttributes:
        //     一个对象，其中包含要为该元素设置的 HTML 特性。
        //
        // 返回结果:
        //     一个定位点元素（a 元素）。
        //
        // 异常:
        //   System.ArgumentException:
        //     linkText 参数为 null 或为空。
        public static MvcHtmlString ActionLinkWithPermission(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, string protocol, string hostName, string fragment, object routeValues, object htmlAttributes)
        {
            return htmlHelper. ActionLink(  linkText,  actionName,  controllerName,  protocol,  hostName,  fragment,  routeValues,  htmlAttributes);
        }
        //
        // 摘要:
        //     返回包含指定操作的虚拟路径的定位点元素（a 元素）。
        //
        // 参数:
        //   htmlHelper:
        //     此方法扩展的 HTML 帮助器实例。
        //
        //   linkText:
        //     定位点元素的内部文本。
        //
        //   actionName:
        //     操作的名称。
        //
        //   controllerName:
        //     控制器的名称。
        //
        //   protocol:
        //     URL 协议，如“http”或“https”。
        //
        //   hostName:
        //     URL 的主机名。
        //
        //   fragment:
        //     URL 片段名称（定位点名称）。
        //
        //   routeValues:
        //     一个包含路由参数的对象。
        //
        //   htmlAttributes:
        //     一个对象，其中包含要为该元素设置的 HTML 特性。
        //
        // 返回结果:
        //     一个定位点元素（a 元素）。
        //
        // 异常:
        //   System.ArgumentException:
        //     linkText 参数为 null 或为空。
        public static MvcHtmlString ActionLinkWithPermission(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, string protocol, string hostName, string fragment, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes)
        {
            return htmlHelper.ActionLink(linkText, actionName, controllerName, protocol, hostName, fragment, routeValues, htmlAttributes);
        }
    }
}
