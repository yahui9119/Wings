using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Wings.DataObjects.Custom;

namespace Wings.DataObjects
    
{

    public class WebDTOList : List<WebDTO>
    {
        public WebDTOList ToViewModel()
        {
            WebDTOList dtolist=new WebDTOList ();
            if (this == null)
            {
                return dtolist;
            }
            this.ForEach(t => {
                WebDTO dto = new WebDTO();
                dto.ID = t.ID;
                dto.IsActive = t.IsActive;
                dto.Name = t.Name;
                dto.Status = t.Status;
                dto.Version = t.Version;
                dto.CreateDate = t.CreateDate;
                dto.Creator = t.Creator;
                dto.Description = t.Description;
                dto.Domain = t.Domain;
                dto.EditDate = t.EditDate;
                dtolist.Add(dto);
            });
            return dtolist;
        }
        public  List<Tree> ToTree()
        {
            List<Tree> trees = new List<Tree>();
            if (this != null)
            {
                this.ForEach(t =>
                {
                    Tree tree = new Tree();
                    tree.id = t.ID;
                    tree.text = t.Name;
                    trees.Add(tree);
                });
            }
            return trees;
        }
      }
    [DataContract]
    public class WebDTO:BaseDTO
    {
     public WebDTO()
        {
            Users = new List<UserDTO>();
            Modules = new List<ModuleDTO>();
        }
     public virtual string _id { get {

         return this.ID;
     } }
        [DataMember]
        /// <summary>
        /// 站点名字
        /// </summary>
        public virtual string Name { get; set; }
        [DataMember]
        /// <summary>
        /// 简介说明
        /// </summary>
        public virtual string Description { get; set; }
        [DataMember]
        /// <summary>
        /// 域名
        /// </summary>
        public virtual string Domain { get; set; }
        [DataMember]
        /// <summary>
        /// 是否启用
        /// </summary>
        public virtual bool IsActive { get; set; }
        [DataMember]
        /// <summary>
        /// 可管理该站点的用户列表
        /// </summary>
        public virtual List<UserDTO> Users { get; set; }
        [DataMember]
        /// <summary>
        /// 站点下菜单模块列表
        /// </summary>
        public virtual List<ModuleDTO> Modules { get; set; }
        //[DataMember]
        ///// <summary>
        ///// 该站点拥有的访问点
        ///// </summary>
        //public virtual List<ActionDTO> Actions { get; set; }
    }
}
