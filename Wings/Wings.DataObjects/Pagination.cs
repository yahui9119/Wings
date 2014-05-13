using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Wings.DataObjects
{
    [DataContract]
    public class Pagination
    {
        public Pagination()
        {
            page = 0;
            rows = 0;
            TotalPages = 0;
            TotalRecords = 0;
            StartTime = null;
            EndTime = null;
            LikeWord = string.Empty;
            IsDesc = false;
            
        }
        [DataMember]
        /// <summary>
        /// 页索引
        /// </summary>
        public int page { get; set; }
        [DataMember]
        /// <summary>
        /// 单页显示大小
        /// </summary>
        public int rows { get; set; }
        [DataMember]
        /// <summary>
        /// 总共多少页
        /// </summary>
        
        public int? TotalPages { get; set; }
        [DataMember]
        /// <summary>
        /// 获取总共多少行
        /// </summary>
        public int TotalRecords { get;set; }
        [DataMember]
        /// <summary>
        /// 数据开始时间
        /// </summary>
        public DateTime? StartTime { get; set; }
        [DataMember]
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? EndTime { get; set; }
        [DataMember]
        /// <summary>
        /// 模糊查询 一般指定名字
        /// </summary>
        public string LikeWord { get; set; }
        [DataMember]
        /// <summary>
        /// 是否倒叙排列
        /// </summary>
        public bool IsDesc { get; set; }
        [DataMember]
        /// <summary>
        /// 排序的列明
        /// </summary>
        public string sort { get; set; }
        [DataMember]
        /// <summary>
        /// 排序方式
        /// </summary>
        public string order { get; set; }
         
    }
}
