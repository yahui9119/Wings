using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wings.Framework.Config;
using Wings.Framework.Plugin.Contracts;
using Wings.Framework.Plugin.Web;

namespace Wings.Framework.Plugin.Services
{
    /// <summary>
    /// 客户端站点实现的服务
    /// </summary>
    public class PluginServiceCallBack : IPluginServiceCallBack
    {
        public void SavePermission(List<Permission> permissions, Guid userid)
        {
            WebSetting.SaveUserPermission(permissions,userid);
        }
        public void SaveConfig(List<ConfiguredString> configs)
        {
            if (configs != null && configs.Count > 0)
            {
                List<ConnectionString> configtrings = new List<ConnectionString>();
                configs.ForEach(c =>
                {
                    configtrings.Add(new ConnectionString() { Key = c.key, Value = c.value });
                });
                WingsConfigurationWrite.SetConfigureString(configtrings);
            }
        }


        public List<Permission> GetAllPermission()
        {
            return WebSetting.GetAllAction();
        }
    }
}
