using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Wings.DataObjects.Custom;

namespace Wings.DataObjects
{

    [CollectionDataContract(Name = "GroupDTOList", ItemName = "GroupDTO", Namespace="http://www.wings.com")]
    public class GroupDTOList : List<GroupDTO>
    {
        /// <summary>
        /// 转换为友好显示树形结构
        /// </summary>
        /// <param name="groupdtolist"></param>
        /// <returns></returns>
        public  List<Tree> ToTree(GroupDTOList groupdtolist=null)
        {
            List<Tree> trees = new List<Tree>();

            if (groupdtolist == null)
            {
                groupdtolist = this;
            }
            if (groupdtolist.Count == 0)
            {
                return null;
            }
           groupdtolist.OrderByDescending(g => g.Index).ToList().ForEach(g =>
                {
                    Tree tree = new Tree();
                    tree.id = g.ID.ToString();
                    tree.text = g.Name;
                    if (g.ChildGroup != null && g.ChildGroup.Count > 0)
                    {
                        tree.children = ToTree((GroupDTOList)g.ChildGroup);
                    }
                    trees.Add(tree);
                });
            return trees;
        }
        public GroupDTOList ToViewModel(List<GroupDTO> groups = null)
        {
            GroupDTOList gdtolist = new GroupDTOList();
            if (groups == null)
            {
                groups=this;
                return ToViewModel(groups);
            }
            else
            {
                groups = groups.OrderByDescending(g => g.Index).ToList() ;
                groups.ForEach(g =>
                {
                    GroupDTO dto = new GroupDTO();
                    dto.CreateDate = g.CreateDate;
                    dto.Creator = g.Creator;
                    dto.Description = g.Description;
                    dto.EditDate = g.EditDate;
                    dto.ID = g.ID.ToString();
                    dto.Name = g.Name;
                    dto.ParentID = g.ParentID;
                    dto.ParentName =g.ParentName;
                    dto.Status = (Wings.DataObjects.Status)g.Status;
                    dto.Index = g.Index;
                    if (g.ChildGroup != null && g.ChildGroup.Count > 0)
                    {
                        dto.ChildGroup=this.ToViewModel(g.ChildGroup);
                    }
                    gdtolist.Add(dto);
                });
            }
            return gdtolist;
        }
    }
    [DataContract]
    [Serializable]
    public class GroupDTO : BaseDTO, IExtensibleDataObject
    {
        public GroupDTO()
        {
            //ChildGroup = new List<GroupDTO>();
            //Users = new List<UserDTO>();
        }
        [DataMember]
        /// <summary>
        /// 分组名字
        /// </summary>
        public virtual string Name { get; set; }
        [DataMember]
        /// <summary>
        /// 简介说明
        /// </summary>
        public virtual string Description { get; set; }
        [DataMember]
        /// <summary>
        /// 父组
        /// </summary>
        public virtual GroupDTO ParentGroup { get; set; }
        private Guid _parentid = Guid.Empty;
        [DataMember]
        /// <summary>
        /// 父节点ID
        /// </summary>
        public virtual Guid? ParentID { get; set; }
        public Guid? _parentId
        {
            get {
                return ParentID.HasValue?ParentID.Value == Guid.Empty ? null : ParentID:null;
        } }
        //{
        //    get
        //    {
        //        if (ParentGroup != null)
        //        {
        //            Guid temp = Guid.Empty;
        //            if (Guid.TryParse(ParentGroup.ID, out temp))
        //            {
        //                return temp;
        //            }
        //        }
        //        return _parentid;
        //    }
        //    set
        //    {
        //        Guid temp = Guid.Empty;
        //        if (Guid.TryParse(value.ToString(), out temp)&&value!=Guid.Empty)
        //        {
        //            ParentGroup = new GroupDTO();
        //            ParentGroup.ID = value.ToString();
        //        }
        //        _parentid = value;
        //    }
        //}
        [DataMember]
        /// <summary>
        /// 排序
        /// </summary>
        public virtual int Index { get; set; }
        private string _parentname=string.Empty;
        [DataMember]
        /// <summary>
        /// 父节点名字
        /// </summary>
        public virtual string ParentName
        {

            get
            {
                if (ParentGroup != null)
                {
                    return ParentGroup.Name;
                }
                return _parentname;
            }
            set
            {
                //if (!string.IsNullOrEmpty(value))
                //{
                //    ParentGroup = new GroupDTO();
                //    ParentGroup.Name = value.ToString();
                //}
                _parentname = value;
            }
        }
        [DataMember]
        /// <summary>
        /// 子分组
        /// </summary>
        public virtual List<GroupDTO> ChildGroup { get; set; }
        /// <summary>
        /// 该分组下的用户
        /// </summary>
        [DataMember]
        public virtual List<UserDTO> Users { get; set; }
        /// <summary>
        /// 该用户组拥有的模块
        /// </summary>
        [DataMember]
        public virtual List<ModuleDTO> Modules { get; set; }

        public ExtensionDataObject ExtensionData

        { get; set; }

    }
}
