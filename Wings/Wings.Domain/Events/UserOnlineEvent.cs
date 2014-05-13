using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wings.Domain.Events
{
    /// <summary>
    /// 用户上线事件
    /// </summary>
    public class UserOnlineEvent:DomainEvent
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public Guid UserID { get; set; }
        /// <summary>
        /// 站点id
        /// </summary>
        public Guid WebID { get; set; }
        /// <summary>
        /// 上线时间
        /// </summary>
        public DateTime OnLineDate { get; set; }
        public UserOnlineEvent() { }
        public UserOnlineEvent(IEntity entity) : base(entity) { }
    }
}
