using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wings.DataObjects.Custom
{
    [Serializable]
    public class Result
    {
        public bool success { get; set; }
        public string message { get; set; }
        public object data { get; set; }
    }
}
