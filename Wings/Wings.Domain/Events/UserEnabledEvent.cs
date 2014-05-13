using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wings.Domain.Events
{
    /// <summary>
    /// 标示用户启用事件
    /// </summary>
    [Serializable]
    public class UserEnabledEvent:DomainEvent
    {public UserEnabledEvent() { }
    public UserEnabledEvent(IEntity source) : base(source) { }
        /// <summary>
        /// 启用的时间
        /// </summary>
        public DateTime EnableDate { get; set; }
        /// <summary>
        /// 被禁用的用户id
        /// </summary>
        public Guid UserID { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 用户邮件
        /// </summary>
        public string UserEmail { get; set; }
    }
}
