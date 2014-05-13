using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Wings.DataObjects
{
    [DataContract]
    [Serializable]
    public class BaseDTO
    {
          [DataMember]
        /// <summary>
        /// 唯一标示
        /// </summary>
        public string ID { get; set; }
          [DataMember]
        /// <summary>
        /// 创建者标示
        /// </summary>
        public Guid? Creator { get; set; }
          [DataMember]
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }
          [DataMember]
        /// <summary>
        /// 最后编辑时间
        /// </summary>
        public DateTime EditDate { get; set; }
          [DataMember]
        /// <summary>
        ///  状态
        /// </summary>
        public Status Status { get; set; }
          [DataMember]
        /// <summary>
        /// 版本号 数据版本控制
        /// </summary>
        public byte[] Version { get; set; }
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
