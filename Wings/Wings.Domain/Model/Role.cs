using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wings.Domain.Model
{
    /// <summary>
    /// 标示角色领域的实体
    /// </summary>
    public class Role:AggregateRoot
    {
        public Role()
        {
            Users = new List<User>();
        }
        /// <summary>
        /// 角色名
        /// </summary>
        public virtual string Name { get; set; }
        /// <summary>
        /// 简介说明
        /// </summary>
        public virtual string Description { get; set; }
        /// <summary>
        /// 拥有的用户列表
        /// </summary>
        public virtual List<User> Users { get; set; }
        /// <summary>
        /// 该角色拥有的模块
        /// </summary>
        public virtual List<Module> Modules { get; set; }
    }
}
