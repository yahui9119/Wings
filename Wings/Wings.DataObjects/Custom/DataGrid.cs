using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wings.DataObjects.Custom
{
    /// <summary>
    /// 数据表
    /// </summary>
    [Serializable]
    public class DataGrid
    {
        public int ?total { get; set; }
        public object rows { get; set; }
    }
}
