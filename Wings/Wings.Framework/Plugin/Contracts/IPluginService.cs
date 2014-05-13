using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Wings.Framework.Plugin.Contracts
{
    /// <summary>
    /// 插件服务契约
    /// </summary>

    [ServiceContract(Namespace = "http://www.wings.com", CallbackContract = typeof(IPluginServiceCallBack))]
    public interface IPluginService
    {
        /// <summary>
        /// 初始化站点的访问点信息
        ///服务端拥有的以站点实际拥有的为准
        /// </summary>
        /// <param name="webid"></param>
        /// <param name="permission"></param>
        [OperationContract(IsOneWay = false)]
        void Init(Guid webid, List<Permission> permission);
        /// <summary>
        /// 用户在一个站点登录
        /// 返回用户id
        /// </summary>
        /// <param name="account">账号名字</param>
        /// <param name="password">经过MD5加密</param>
        /// <param name="webid"></param>
        [OperationContract(IsOneWay = false)]
        UserInfo Login(string account, string password, Guid webid);
        /// <summary>
        /// 获取用户
        /// </summary>
        /// <param name="accountid">用户id</param>
        /// <param name="webid">站点id</param>
        /// <param name="IsAdmin">是否是超级管理员</param>
        /// <returns></returns>
        [OperationContract(IsOneWay = false)]
        List<Permission> GetPermissionByUserID(Guid accountid, Guid webid,bool IsAdmin=false);
        /// <summary>
        /// 登出
        /// </summary>
        /// <param name="account"></param>
        [OperationContract(IsOneWay = false)]
        void LoginOut(Guid accountid,Guid webid);
        /// <summary>
        /// 在线心跳
        /// </summary>
        /// <param name="account"></param>
        [OperationContract(IsOneWay = false)]
        void OnlineHeartbeat(Guid accountid, Guid webid);
    }
}
