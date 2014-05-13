using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wings.Domain.Events;

namespace Wings.Domain.Model
{
    /// <summary>
    /// 标示用户在线领域的实体
    /// </summary>
    public class UserOnline:AggregateRoot
    {
        /// <summary>
        /// 在线的用户
        /// </summary>
        public virtual User user { get; set; }
        /// <summary>
        /// 已经在线的时间
        /// </summary>
        public virtual DateTime OnlineTime { get; set; }
        /// <summary>
        /// 在线的站点
        /// </summary>
        public virtual Web web { get; set; }
        /// <summary>
        /// 当前是否在线
        /// </summary>
        public virtual bool IsOnline { get; set; }
        /// <summary>
        /// 上线
        /// </summary>
        public void Online()
        {
            DomainEvent.Publish<UserOnlineEvent>(new UserOnlineEvent(this));
        }
        /// <summary>
        /// 下线
        /// </summary>
        public void Offline()
        {
            DomainEvent.Publish<UserOfflineEvent>(new UserOfflineEvent(this));
        }
    }
}
