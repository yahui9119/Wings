using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wings.Domain.Model
{
    /// <summary>
    /// 表示聚合根类型的基类型。
    /// </summary>
    public abstract class AggregateRoot : IAggregateRoot
    {
        public AggregateRoot()
        {
            CreateDate = DateTime.Now;
            EditDate = DateTime.Now;

        }
        #region Protected Fields
        protected Guid id;
        #endregion

        #region Public Methods
        /// <summary>
        /// 确定指定的Object是否等于当前的Object。
        /// </summary>
        /// <param name="obj">要与当前对象进行比较的对象。</param>
        /// <returns>如果指定的Object与当前Object相等，则返回true，否则返回false。</returns>
        /// <remarks>有关此函数的更多信息，请参见：http://msdn.microsoft.com/zh-cn/library/system.object.equals。
        /// </remarks>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            IAggregateRoot ar = obj as IAggregateRoot;
            if (ar == null)
                return false;
            return this.id == ar.ID;
        }
        /// <summary>
        /// 用作特定类型的哈希函数。
        /// </summary>
        /// <returns>当前Object的哈希代码。</returns>
        /// <remarks>有关此函数的更多信息，请参见：http://msdn.microsoft.com/zh-cn/library/system.object.gethashcode。
        /// </remarks>
        public override int GetHashCode()
        {
            return this.id.GetHashCode();
        }
        #endregion

        #region IEntity Members
        /// <summary>
        /// 获取当前领域实体类的全局唯一标识。
        /// </summary>
        public Guid ID
        {
            get { return id; }
            set { id = value; }
        }
        /// <summary>
        /// 创建者
        /// </summary>
        public Guid? Creator { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 最后一次修改时间
        /// </summary>
        public DateTime EditDate { get; set; }
        public Status Status { get; set; }
        /// <summary>
        /// 版本号 数据版本控制
        /// </summary>
        public byte[] Version { get; set; }
        #endregion
    }
    public enum Status:int
    {
        /// <summary>
        /// 已经删除
        /// </summary>
        Deleted=-1,
        /// <summary>
        /// 禁用，隐藏
        /// </summary>
        Forbidden=0,
        /// <summary>
        /// 正常使用
        /// </summary>
        Active=1,
        /// <summary>
        /// 未激活
        /// </summary>
        UnActivated=2
        
    }
}
