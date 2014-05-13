using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Wings.DataObjects
{

    [Serializable]
    [DataContract]
    public class MenusDTO
    {
          [DataMember]
        public string ID { get; set; }
          [DataMember]
        public string Name { get; set; }
          [DataMember]
        public string Url = "javascript:;";
          [DataMember]
        public string ICO { get; set; }
          [DataMember]
        public List<MenusDTO> ChildMenus { get; set; }
    }
}
