using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Wings.Admin.Models
{

    public class LoginModel
    {
        [Required(ErrorMessage="帐户名不能为空！")]
        [Display(Name = "用户名：")]
        public string Account { get; set; }

        [Required(ErrorMessage="密码不能为空！")]
        [DataType(DataType.Password)]
        [Display(Name = "密码：")]
        public string Password { get; set; }
        [Required(ErrorMessage="验证码不能为空！")]
        [Display(Name = "验证码：")]
        public string CheckCode { get; set; }

        [Display(Name = "记住我?")]
        public bool RememberMe { get; set; }
    }
}