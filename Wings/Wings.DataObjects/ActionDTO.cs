using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Wings.DataObjects.Custom;

namespace Wings.DataObjects
{

    //public class ActionDTOList : List<ActionDTO>
    //{
    //    /// <summary>
    //    /// 转换为属性结构
    //    /// child 为null时时对对象本身的转换
    //    /// </summary>
    //    /// <param name="child"></param>
    //    /// <returns></returns>
    //    public List<Tree> ToTree(List<ActionDTO> child=null)
    //    {
    //        List<Tree> trees = new List<Tree>();
    //        if (this != null)
    //        {
    //            var result = child == null ? this.ToList() : child;

    //            result.ForEach(t =>
    //                {
    //                    Tree tree = new Tree();
    //                    tree.id = t.ID;
    //                    tree.text = t.ActionName;
    //                    //if (t.ChildAction != null && t.ChildAction.Count > 0)
    //                    //{
    //                    //    tree.children = ToTree(t.ChildAction);
    //                    //}
    //                    trees.Add(tree);
    //                });
    //        }
    //        return trees;
    //    }
    //    /// <summary>
    //    ///  转换为可序列化的数据列表
    //    ///  坑爹的Entity Framework
    //    /// </summary>
    //    /// <param name="child"></param>
    //    /// <returns></returns>
    //    public ActionDTOList ToViewModel(List<ActionDTO> child)
    //    {
    //        ActionDTOList dtolist = new ActionDTOList();
    //        if (this != null)
    //        {
    //            var result = child == null ? this.ToList() : child;
    //            result.ForEach(a => {
    //                ActionDTO dto = new ActionDTO();
    //                dto.ActionName = a.ActionName;
    //                dto.Controller = a.Controller;
    //                dto.CreateDate = a.CreateDate;
    //                dto.Creator = a.Creator;
    //                dto.Description = a.Description;
    //                dto.EditDate = a.EditDate;
    //                dto.ID = a.ID;
    //                dto.IsButton = a.IsButton;
    //                dto.Status = a.Status;
    //                dto.Version = a.Version;
    //                dtolist.Add(dto);
    //            });
    //        }
    //        return dtolist;
    //    }
    //}


    ///// <summary>
    ///// 标示可访问点的领域的实体
    ///// </summary>
    //[DataContract]
    //public class ActionDTO : BaseDTO
    //{

    //    public ActionDTO()
    //    {
    //        //ChildAction = new List<ActionDTO>();
    //    }
    //    [DataMember]
    //    public virtual WebDTO web { get; set; }
    //    /// <summary>
    //    /// 模块控制器
    //    /// </summary>
    //    [DataMember]
    //    public virtual string Controller { get; set; }
    //    [DataMember]
    //    /// <summary>
    //    /// 模块访问点
    //    /// </summary>
    //    public virtual string ActionName { get; set; }
    //    [DataMember]
    //    /// <summary>
    //    /// 说明 简介
    //    /// </summary>
    //    public virtual string Description { get; set; }
    //    /// <summary>
    //    /// 视图ationid
    //    /// </summary>
    //    [DataMember]
    //    public virtual Guid ViewActionID { get; set; }
    //    //[DataMember]
    //    /////// <summary>
    //    /////// 父访问点
    //    /////// </summary>
    //    //public virtual ActionDTO ParentAction { get; set; }
    //    //[DataMember]
    //    ///// <summary>
    //    ///// 子访问点
    //    ///// </summary>
    //    //public virtual List<ActionDTO> ChildAction { get; set; }
    //    [DataMember]

    //    /// <summary>
    //    /// 是否是按钮
    //    /// </summary>
    //    public virtual bool IsButton { get; set; }
    //}
}
