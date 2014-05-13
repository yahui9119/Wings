using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wings.Framework.Plugin.Contracts;

namespace Wings.Domain.Events
{
    /// <summary>
    /// 更新用户的权限事件
    /// </summary>
    [Serializable]
    public class UserUpdatePermissionEvent : DomainEvent
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public Guid UserID { get; set; }
        /// <summary>
        /// 站点id
        /// </summary>
        public Guid WebID { get; set; }
        ///// <summary>
        ///// 更新权限
        ///// </summary>
        //public List<Permission> Permissions { get; set; }
        public UserUpdatePermissionEvent() { }
        public UserUpdatePermissionEvent(IEntity entity) : base(entity) { }

    }
}
