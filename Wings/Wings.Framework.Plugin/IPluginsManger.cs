using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wings.Framework.Plugin
{
    public interface IPluginsManger
    {
        /// <summary>
        /// 安装插件
        /// </summary>
        /// <param name="plugin">插件</param>
        /// <returns></returns>
        bool InstallPlugin(IPlugin plugin);
        /// <summary>
        /// 卸载插件
        /// </summary>
        /// <param name="plugin">插件</param>
        /// <returns></returns>
        bool UnInstallPlugin(IPlugin plugin);
    }
}
