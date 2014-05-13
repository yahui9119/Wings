using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Wings.DataObjects.Custom;

namespace Wings.DataObjects
{

    public class RoleDTOList : List<RoleDTO>
    {
        public RoleDTOList ToViewModel()
        {
            RoleDTOList viewmodels = new RoleDTOList();
            if (this != null)
            {
                this.ForEach(r => 
                {
                   
                    viewmodels.Add(r.ToViewModule());
                });
            }
            return viewmodels;
        }
        public List<Tree> ToTree()
        {
            List<Tree> trees = new List<Tree>();
            if (this != null)
            {
                this.ForEach(r =>
                {
                    Tree tree = new Tree();
                    tree.id = r.ID;
                    tree.text = r.Name;
                    trees.Add(tree);
                });
            }
            return trees;
        }
    }
    [DataContract]
    public class RoleDTO : BaseDTO
    {
        public RoleDTO()
        {
            Users = new List<UserDTO>();
        }
        public RoleDTO ToViewModule()
        {
            RoleDTO dto = new RoleDTO();
            dto.ID = this.ID;
            dto.Name = this.Name;
            dto.Status = this.Status;
            dto.Version = this.Version;
            dto.CreateDate = this.CreateDate;
            dto.Creator = this.Creator;
            dto.Description = this.Description;
            dto.EditDate = this.EditDate;
            return dto;
        }
        [DataMember]
        /// <summary>
        /// 角色名
        /// </summary>
        public virtual string Name { get; set; }
        [DataMember]
        /// <summary>
        /// 简介说明
        /// </summary>
        public virtual string Description { get; set; }
        [DataMember]
        /// <summary>
        /// 拥有的用户列表
        /// </summary>
        public virtual List<UserDTO> Users { get; set; }
        [DataMember]
        /// <summary>
        /// 该角色拥有的模块
        /// </summary>
        public virtual List<ModuleDTO> Modules { get; set; }
    }
}
