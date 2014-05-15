using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wings.Domain.Model
{
    /// <summary>
    /// 站点连接字符的实体领域
    /// </summary>
    public class Connection : AggregateRoot
    {
        /// <summary>
        /// 链接字符串名字
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 介绍
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 链接字符串
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// 加密方式
        /// </summary>
        public string EncryType { get;set;}
        /// <summary>
        /// 加密解密key
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// 偏移量
        /// </summary>
        public string Offset { get; set; }
        /// <summary>
        /// 使用此链接的站点
        /// </summary>
        public List<Web> Webs { get; set; }
        
    }
}
