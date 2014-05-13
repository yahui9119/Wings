using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Wings.Framework.Plugin.Contracts
{
    /// <summary>
    /// 权限数据契约
    /// </summary>
    [DataContract]
    [Serializable]
    public class Permission
    {
        /// <summary>
        /// 模块标示
        /// </summary>
        [DataMember]
        public Guid ID { get; set; }
        /// <summary>
        /// 模块名字
        /// </summary>
        [DataMember]
        public string Name { get; set; }
        /// <summary>
        /// 控制器
        /// </summary>
        [DataMember]
        public string Controller { get; set; }
        /// <summary>
        /// 访问点
        /// </summary>
        [DataMember]
        public string Action { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [DataMember]
        public string Description { get; set; }
        /// <summary>
        /// 是否是post提交的action
        /// </summary>
        [DataMember]
        public bool IsPost { get; set; }
        [DataMember]
        /// <summary>
        /// 转跳链接
        /// </summary>
        public string Url { get; set; }
        [DataMember]
        /// <summary>
        /// 打开类型
        /// </summary>
        public string Target { get; set; }
        [DataMember]
        /// <summary>
        /// 图标
        /// </summary>
        public string ICON { get; set; }
        [DataMember]
        /// <summary>
        /// 排序索引
        /// </summary>
        public int Index { get; set; }
        [DataMember]
        /// <summary>
        /// 是否是菜单
        /// </summary>
        public bool IsMenus { get; set; }
        [DataMember]
        /// <summary>
        /// 父菜单标识
        /// </summary>
        public Guid? _parentId { get; set; }
    }
}
