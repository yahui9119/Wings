using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wings.Domain.Model
{
    /// <summary>
    /// 表示站点领域的值的对象
    /// </summary>
    public class Web : AggregateRoot
    {
        public Web()
        {
            Users = new List<User>();
            Modules = new List<Module>();
        }
        /// <summary>
        /// 站点名字
        /// </summary>
        public virtual string Name { get; set; }
        /// <summary>
        /// 简介说明
        /// </summary>
        public virtual string Description { get; set; }
        /// <summary>
        /// 域名
        /// </summary>
        public virtual string Domain { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public virtual bool IsActive { get; set; }
        /// <summary>
        /// 可管理该站点的用户列表
        /// </summary>
        public virtual List<User> Users { get; set; }
        /// <summary>
        /// 站点下菜单模块列表
        /// </summary>
        public virtual List<Module> Modules { get; set; }
        /// <summary>
        /// 使用的连接字符串
        /// </summary>
        public virtual List<Connection> Connections { get; set; }
        ///// <summary>
        ///// 该站点拥有的访问点
        ///// </summary>
        //public virtual List<Action> Actions { get; set; }
    }
}
