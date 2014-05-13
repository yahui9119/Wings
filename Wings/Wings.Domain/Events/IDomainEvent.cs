using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wings.Domain.Events
{
    /// <summary>
    /// 标示领域时间的接口，所有继承与此接口的类型都是一种领域事件
    /// </summary>
    public interface IDomainEvent : Wings.Framework.Events.IEvent
    {
        #region Properties
        /// <summary>
        /// 获取产生领域事件的事件源对象。
        /// </summary>
        IEntity Source { get; }
        #endregion
    }
}
