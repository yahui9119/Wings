using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Wings.DataObjects
{
    /// <summary>
    /// 数据列表分页数据信息
    /// </summary>
    /// <typeparam name="T">数据列表</typeparam>
      [DataContract]
    public class DataObjectListWithPagination<T> where T : new() //List<BaseDTO>,
    {
        public DataObjectListWithPagination()
        {
            pagination = new Pagination();
            pagination.rows = 10;
            pagination.page = 1;
            DataObjectList = new T();;

        }
            [DataMember]
        /// <summary>
        /// 分页信息
        /// </summary>
        public Pagination pagination { get; set; }
        /// <summary>
        /// 数据列表
        /// </summary>
          [DataMember]
        public T DataObjectList { get; set; }
    }
}
