using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using Wings.Framework.Plugin.Contracts;
using Wings.Framework.Plugin.Services;
using Wings.Framework.Routes;

namespace Wings.Framework.Plugin
{
    public class PluginsManger : IPluginsManger
    {
        private static int time = 0;
        private static Timer timer = new Timer(t =>
        {
            time++;
            if (time >= 3)//30s
            {
                time = 0;
                try
                {
                    _service.OnlineHeartbeat(Guid.Empty, Guid.Empty);
                }
                catch (Exception ex)
                {
                    Log.Instance.Error("【心跳】异常\r\n", ex);
                }
               
            }

        }, null, 0, 1000 * 10);//10s
        /// <summary>
        /// 站点扩展初始化
        /// </summary>
        public static void Init()
        {
            Service.Init(Wings.Framework.Config.WingsConfigurationReader.Instance.WebID, Web.WebSetting.GetAllAction());

        }
        private static IPluginService _service;
        public static IPluginService Service
        {
            get
            {
                time = 0;
                if (_service == null)
                {
                    InstanceContext instanceContext = new InstanceContext(new PluginServiceCallBack());
                    DuplexChannelFactory<IPluginService> channelFactory = new DuplexChannelFactory<IPluginService>(instanceContext, "PluginService");
                    _service = channelFactory.CreateChannel();
                }
                try
                {
                    _service.OnlineHeartbeat(Guid.Empty, Guid.Empty);
                }
                catch (Exception ex)
                {

                   Log.Instance.Error(ex);
                    InstanceContext instanceContext = new InstanceContext(new PluginServiceCallBack());
                    DuplexChannelFactory<IPluginService> channelFactory = new DuplexChannelFactory<IPluginService>(instanceContext, "PluginService");
                    _service = channelFactory.CreateChannel();
                }
                return _service;


            }
        }

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
