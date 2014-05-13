using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wings.Framework.Infrastructure
{
    /// <summary>
    /// 表示所有集成该接口的类型都是Unit of work 的一种实现。
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// 获取一个布尔值 该值表示当前的unit of word是否支持microsoft分布式事务处理机制
        /// </summary>
        bool DistributedTransactionSupported { get; }
        /// <summary>
        /// 表示当前工作单元是否已经被提交
        /// </summary>
        bool Committed { get; }
        /// <summary>
        /// 提交当前的工作单元事务
        /// </summary>
        void Commit();
        /// <summary>
        /// 回滚当前的工作单元事务
        /// </summary>
        void Rollback();
    }
}
