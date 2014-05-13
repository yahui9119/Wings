using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wings.DataObjects.Custom
{
    /// <summary>
    /// 界面友好显示的树形结构
    /// </summary>
    public class Tree
    {
        public string id { get; set; }
        public string text { get; set; }
        public string iconCls { get; set; }
        public string state { get; set; }
        public object attributes { get; set; }
        public List<Tree> children { get; set; }
    }
}
