using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;
using Wings.Admin.Models;
using Wings.Contracts;
using Wings.DataObjects;
using Wings.DataObjects.Custom;
using Wings.Framework;
using Wings.Framework.Communication;
using Wings.Framework.Plugin;
using Wings.Framework.Plugin.UI;
using Wings.Framework.Plugin.Web;
using Wings.Framework.Utils;
using Wings.Framework.Utils.ValidateCode;

namespace Wings.Admin.Controllers
{
    public class AccountController : WingsController
    {
        //
        // GET: /Account/
        [Description("[站点登录显示页面]")]
        [Anonymous]
        public ActionResult Login()
        {
           
           
            return View();
        }


        [HttpPost]
        [Anonymous]
        //[ValidateAntiForgeryToken]
        [Description("[站点登录接受提交页面]")]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            var webid = Wings.Framework.Config.WingsConfigurationReader.Instance.WebID;
            var adminid = Wings.Framework.Config.WingsConfigurationReader.Instance.WebAdminID;
            string errormsg = string.Empty;
            if (ModelState.IsValid)
            {
                if (!VerificationCode.TestCode(model.CheckCode))
                {
                    errormsg += "验证码不正确。";
                    //ModelState.AddModelError("", "验证码不正确。");

                }
                else
                {
                    var account = PluginsManger.Service.Login(model.Account, model.Password, webid);
                    if (account == null || account.Equals(Guid.Empty))
                    {
                        errormsg += "提供的账户或密码不正确。";
                        //ModelState.AddModelError("", "提供的账户或密码不正确。");
                    }
                    else
                    {
                        var PermissionList = PluginsManger.Service.GetPermissionByUserID(account.ID, webid, adminid == account.ID);
                        WebSetting.UserOnline(account, model.RememberMe);
                        WebSetting.SaveUserPermission(PermissionList);
                    }
                }
            }
            bool state = true;
            // 如果我们进行到这一步时某个地方出错，则重新显示表单
            if (!string.IsNullOrWhiteSpace(errormsg))
            {
                state = false;
                ModelState.AddModelError("", errormsg);
            }
           
            return View(model);
        }
        [Description("[站点登出]")]
        [LoginAllowView]
        public ActionResult LogOut()
        {
            var webid = Wings.Framework.Config.WingsConfigurationReader.Instance.WebID;
            var userinfo = WebSetting.GetUser();
            Result r = new Result();
            
            if (userinfo != null)
            {
                try
                {
                    PluginsManger.Service.LoginOut(userinfo.ID, webid);
                    r.success = true;
                }
                catch (Exception ex)
                {
                    r.message = ex.Message;
                }
               
            }
            WebSetting.UserOffLine();
           
            return View();
        }
        /// <summary>
        /// 验证码
        /// </summary>
        /// <returns></returns>\
        [Description("[获取验证码]")]
        [Anonymous]
        public FileContentResult GetVerifyCode()
        {
            string verifyCode = Text.CreateRandomCode(4);
           
            using (System.IO.MemoryStream m = new System.IO.MemoryStream())
            {
                VerificationCode va = new VerificationCode(90, 30, 1, 1, 199, 10);
                var s = va.Create(verifyCode, m);
                return File(m.ToArray(), "image/gif");
            }
        }
    }
}
