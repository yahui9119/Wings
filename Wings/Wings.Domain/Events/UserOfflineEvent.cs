using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wings.Domain.Events
{
    /// <summary>
    /// 用户下线事件
    /// </summary>
    public class UserOfflineEvent:DomainEvent
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
        /// 下线时间
        /// </summary>
        public DateTime OffLineDate { get; set; }
        public UserOfflineEvent() { }
        public UserOfflineEvent(IEntity entity) : base(entity) { }
    }
}
