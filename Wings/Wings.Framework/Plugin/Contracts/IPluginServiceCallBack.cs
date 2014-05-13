using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Wings.Framework.Plugin.Contracts
{
    /// <summary>
    /// 扩展站点服务双工通信回调
    /// </summary>
    [ServiceContract(Namespace = "http://www.wings.com")]
    public interface IPluginServiceCallBack
    {
        /// <summary>
        /// 更新站点此用户的权限
        /// </summary>
        [OperationContract(IsOneWay = false)]
        void SavePermission(List<Permission> permissions, Guid userid);
        /// <summary>
        /// 更新站点的配置信息
        /// </summary>
        [OperationContract(IsOneWay = false)]
        void SaveConfig(List<ConfiguredString> configs);
        /// <summary>
        /// 获取此站点的所有访问点
        /// </summary>
        /// <returns></returns>
        [OperationContract(IsOneWay = false)]
        List<Permission> GetAllPermission();
    }
}
