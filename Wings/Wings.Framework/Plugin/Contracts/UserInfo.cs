using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Wings.Framework.Plugin.Contracts
{
    /// <summary>
    /// 登录后返回的用户信息
    /// </summary>
    [Serializable]
    [DataContract]
    public class UserInfo
    {
        [DataMember]
        /// <summary>
        /// 标识id
        /// </summary>
        public Guid ID { get; set; }

        [DataMember]
        /// <summary>
        /// 用户名
        /// </summary>
        public virtual string Account { get; set; }
        [DataMember]
        /// <summary>
        /// 真实姓名
        /// </summary>
        public virtual string RealName { get; set; }
    }
}
