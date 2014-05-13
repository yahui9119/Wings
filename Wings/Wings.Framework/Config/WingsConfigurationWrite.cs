using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wings.Framework.Plugin.Contracts;

namespace Wings.Framework.Config
{
    public class WingsConfigurationWrite
    {
        private readonly WingsConfigurationSection configuration;
        private static WingsConfigurationWrite instance = new WingsConfigurationWrite();
        public static WingsConfigurationWrite Instance
        {
            get
            {
                return instance;
            }
        }
        static WingsConfigurationWrite() { }
        private WingsConfigurationWrite()
        {
            this.configuration = WingsConfigurationSection.Instance;
            if (this.configuration == null)
            {
                throw new System.Configuration.ConfigurationErrorsException("当前应用程序的配置文件不存在与Wings相关的配置信息。");
            }
        }
        /// <summary>
        /// 设置连接字符串
        /// </summary>
        public static void SetConfigureString(List<ConnectionString> configures)
        {

            configures.ForEach(c =>
            {
                var config = Instance.configuration.ConnectionStrings.GetItemByKey(c.Key);
                if (config != null)
                {
                    Instance.configuration.ConnectionStrings.Remove(config);
                }
                Instance.configuration.ConnectionStrings.Add(c);
            });
            //清空不存在
            foreach (ConnectionString item in Instance.configuration.ConnectionStrings)
            {
                if (!configures.Contains(item))
                {
                    Instance.configuration.ConnectionStrings.Remove(item);
                }
            }
        }
    }
}
