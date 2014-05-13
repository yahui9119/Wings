using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wings.Domain.Model;

namespace Wings.Domain.Events
{
    /// <summary>
    /// 用户角色跟新
    /// </summary>
    public class UserRoleUpdateEvent:DomainEvent
    {
        public UserRoleUpdateEvent() { }
        public UserRoleUpdateEvent(IEntity source) : base(source) { }
        /// <summary>
        /// 角色
        /// </summary>
        public Dictionary<Guid, string> Roles { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public Guid UserID { get; set; }
        /// <summary>
        /// 跟新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }
    }
}
