using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wings.Domain.Model;

namespace Wings.Domain.Events
{
    /// <summary>
    /// 用户可管理站点更新事件
    /// </summary>
    public class UserWebUpdateEvent : DomainEvent
    {
        public UserWebUpdateEvent() { }
        public UserWebUpdateEvent(IEntity entity) : base(entity) { }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 用户邮件
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 现在拥有站点
        /// </summary>
        public Dictionary<Guid, string> Webs { get; set; }
        /// <summary>
        /// 用户标示
        /// </summary>
        public Guid UserID { get; set; }

    }
}
