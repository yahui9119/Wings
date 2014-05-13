using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wings.Domain.Model
{
    /// <summary>
    /// 标示模块领域的实体
    /// </summary>
    public class Module:AggregateRoot
    {
        public Module()
        {
            ChildModule = new List<Module>();
        }
        /// <summary>
        /// 菜单名
        /// </summary>
        public virtual string Name { get; set; }
        /// <summary>
        /// 详情
        /// </summary>
        public virtual string Description { get; set; }
        /// <summary>
        /// 使用的控制器名字 
        /// 可以为空
        /// </summary>
        public virtual string ControllerName { get; set; }
        /// <summary>
        /// 使用的访问点名字
        /// </summary>
        public virtual string ActionName { get; set; }
        /// <summary>
        /// 是否是post请求
        /// 默认为false
        /// </summary>
        public virtual bool IsPost { get; set; }
        /// <summary>
        /// 转跳链接
        /// </summary>
        public virtual string Url { get; set; }
        /// <summary>
        /// 打开类型
        /// </summary>
        public virtual string Target { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        public virtual string ICON { get; set; }
        
        /// <summary>
        /// 排序索引
        /// </summary>
        public virtual int Index { get; set; }
        /// <summary>
        /// 父栏目
        /// </summary>
        public virtual Module ParentModule { get; set; }
        /// <summary>
        /// 子菜单
        /// </summary>
        public virtual List<Module> ChildModule { get; set; }
        /// <summary>
        /// 是否是菜单
        /// </summary>
        public virtual bool IsMenus { get; set; }
        /// <summary>
        /// 所属的站点
        /// </summary>
        public virtual Web Web { get; set; }
        /// <summary>
        /// 拥有着的分组
        /// </summary>
        public virtual List<Group> Groups { get; set; }
        /// <summary>
        /// 拥有着的角色
        /// </summary>
        public virtual List<Role> Roles { get; set; }
        /// <summary>
        /// 被允许的用户
        /// </summary>
        public virtual List<User> UserAllow { get; set; }
        /// <summary>
        /// 不被允许的用户
        /// </summary>
        public virtual List<User> UserBan { get; set; }
        
    }
}
