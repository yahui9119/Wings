using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wings.Domain.Model
{
    /// <summary>
    /// 标示分组的领域的实体
    /// </summary>
    public class Group : AggregateRoot
    {
        public Group()
        {
            ChildGroup = new List<Group>();
            Users = new List<User>();
        }
        /// <summary>
        /// 分组名字
        /// </summary>
        public virtual string Name { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public virtual int Index { get; set; }
        /// <summary>
        /// 简介说明
        /// </summary>
        public virtual string Description { get; set; }
        /// <summary>
        /// 父组
        /// </summary>
        public virtual  Group ParentGroup { get; set; }
        /// <summary>
        /// 子分组
        /// </summary>
        public virtual List<Group> ChildGroup { get; set; }
        /// <summary>
        /// 该分组下的用户
        /// </summary>
        public virtual List<User> Users { get; set; }
        /// <summary>
        /// 该用户组拥有的模块
        /// </summary>
        public virtual List<Module> Modules { get; set; }
    }
}
