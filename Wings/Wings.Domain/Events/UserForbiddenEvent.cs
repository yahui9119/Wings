using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wings.Domain.Events
{
    /// <summary>
    /// 标示用户禁用的领域事件
    /// </summary>
    [Serializable]
    public class UserForbiddenEvent : DomainEvent
    {
        public UserForbiddenEvent() { }
        public UserForbiddenEvent(IEntity source):base(source) { }
        /// <summary>
        /// 禁用的时间
        /// </summary>
        public DateTime ForbinddenDate { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 被禁用的用户id
        /// </summary>
        public Guid UserID { get; set; }
        /// <summary>
        /// 用户邮件
        /// </summary>
        public string UserEmail { get; set; }
    }
}
