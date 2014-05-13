using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wings.Domain
{
    /// <summary>
    /// 标示继承与此接口的类型是聚合根类型。
    /// </summary>
    public interface IAggregateRoot:IEntity
    {
    }
}
