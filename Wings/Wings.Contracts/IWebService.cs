using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Wings.DataObjects;
using Wings.Framework.Infrastructure;
using Wings.Framework.Plugin.Contracts;

namespace Wings.Contracts
{
    /// <summary>
    /// 标示 “站点” 服务的契约
    /// </summary>
    [ServiceContract(Name = "http://www.wings.com")]
    public interface IWebService:ICoreServiceContract
    {
        /// <summary>
        /// 添加新的站点
        /// </summary>
        /// <param name="webdto"></param>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        WebDTOList CreateWeb(WebDTOList webdto);
        /// <summary>
        /// 编辑站点
        /// </summary>
        /// <param name="webdto"></param>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        WebDTOList EditWeb(WebDTOList webdto);
        /// <summary>
        /// 删除现有站点
        /// </summary>
        /// <param name="webid"></param>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        void DeleteWeb(IDList webids);
        /// <summary>
        /// 获取使用此站点下的所有用户
        /// </summary>
        /// <param name="webid"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        UserDTOList GetUsersByWeb(Guid webid);
        /// <summary>
        /// 通过站点id获取站点的基本信息
        /// </summary>
        /// <param name="webid"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        WebDTO GetWebByID(Guid webid);
        /// <summary>
        /// 获取站点的分页
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        DataObjectListWithPagination<WebDTOList> GetWebsByPage(Pagination pagination);
        /// <summary>
        /// 获取所有的站点信息
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        WebDTOList GetAllWebs();
        /// <summary>
        /// 该站点创建模块
        /// </summary>
        /// <param name="webid"></param>
        /// <param name="moduledto"></param>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        ModuleDTO CreateModule(Guid webid, ModuleDTO moduledto);
        /// <summary>
        /// 修改模块
        /// </summary>
        /// <param name="moduledto"></param>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        ModuleDTO EditModule(ModuleDTO moduledto);
        /// <summary>
        /// 删除一个模块
        /// </summary>
        /// <param name="moduleid"></param>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        void DeleteModule(IDList moduleids);
        /// <summary>
        /// 获取所有的有效站点模块
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        ModuleDTOList GetAllWebModules(Guid webid, bool IsMix = false);
        /// <summary>
        /// 根部模块id获取此模块的基本信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        ModuleDTO GetModuleByID(Guid id);
        /// <summary>
        /// 根部模块id获取此模块的基本信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        ModuleDTOList GetModuleByParentID(Guid parentid);
        /// <summary>
        /// 获取站点所有的访问点
        /// </summary>
        /// <param name="WebID"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        List<Permission> GetAllAction(Guid WebID);
    }
}
