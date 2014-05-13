using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace Wings.Framework.Plugin.Contracts
{
    /// <summary>
    /// 客户端连接字符串配置数据契约
    /// </summary>
    [Serializable]
    [DataContract]
    public class ConfiguredString
    {
        [DataMember]
        public string key { get; set; }
        [DataMember]
        public string value { get; set; }
    }
}
