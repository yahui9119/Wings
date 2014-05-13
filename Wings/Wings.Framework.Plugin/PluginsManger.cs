using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wings.Framework.Routes;

namespace Wings.Framework.Plugin
{
    public class PluginsManger : IPluginsManger
    {
        /// <summary>
        /// 安装插件
        /// </summary>
        /// <param name="plugin">插件</param>
        /// <returns></returns>
        public bool InstallPlugin(IPlugin plugin)
        {
            try
            {
                RoutesRegister.RegisterRoute(plugin.routes);
                return true;
            }
            catch (Exception ex)
            {
                //记录日志ex
                return false;
            }
          
        }
        /// <summary>
        /// 卸载插件
        /// </summary>
        /// <param name="plugin">插件</param>
        /// <returns></returns>
        public bool UnInstallPlugin(IPlugin plugin)
        {
            try
            {
                RoutesRegister.DeleteRoute(plugin.routes);
                return true;
            }
            catch (Exception ex)
            {

                //记录日志ex
                return false;
            }
        }
    }
}
