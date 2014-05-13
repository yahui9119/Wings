using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wings.Framework.Plugin.Contracts;

namespace Wings.Framework.Plugin.Utils
{
    /// <summary>
    /// 在线站点回调管道管理
    /// </summary>
    public class ChannelManager
    {
        /// <summary>
        /// 回调通道列表
        /// </summary>
        private Dictionary<Guid, IPluginServiceCallBack> callbackChannelList = new Dictionary<Guid, IPluginServiceCallBack>();
        /// <summary>
        /// 用于互斥锁的对象
        /// </summary>
        public static readonly object SyncObj = new object();
        #region 单例
        private static Lazy<ChannelManager> instance = new Lazy<ChannelManager>(() => new ChannelManager());
        public static ChannelManager Instance
        {
            get { return instance.Value; }

        }
        protected ChannelManager() { }
        #endregion
        /// <summary>
        /// 将回调通道加入到通道列表中进行管理
        /// </summary>
        /// <param name="callbackChannel"></param>
        public  void Add(Guid WebID, IPluginServiceCallBack callbackChannel)
        {
            //if (callbackChannelList.Keys.Contains(WebID))
            //{
            //    Console.WriteLine("已存在重复通道");
            //}
            //else
            {
                lock (SyncObj)
                {
                    callbackChannelList[WebID] = callbackChannel;
                    //callbackChannelList.Add(WebID, callbackChannel);
                    Console.WriteLine("添加了新的通道");
                }
            }
        }
        /// <summary>
        /// 获取单个管道进行操作
        /// 不存在时返回空
        /// </summary>
        /// <param name="callbackChannel"></param>
        public IPluginServiceCallBack Get(Guid WebId)
        {
            if (callbackChannelList.Keys.Contains(WebId))
            {
                return callbackChannelList[WebId];
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 操作遍历所有的管道
        /// </summary>
        /// <param name="action"></param>
        public void ForEach(Action<IPluginServiceCallBack> action)
        {
            callbackChannelList.Values.ToList().ForEach(action);
        }
        /// <summary>
        /// 从通道列表中移除对一个通道的管理
        /// </summary>
        /// <param name="callbackChannel"></param>
        public void Remove(Guid WebID)
        {
            if (!callbackChannelList.Keys.Contains(WebID))
            {
                Console.WriteLine("不存在待移除通道");
            }
            else
            {
                lock (SyncObj)
                {
                    callbackChannelList.Remove(WebID);
                    Console.WriteLine("移除了一个通道");
                }
            }
        }
        public void Remove(IPluginServiceCallBack callback)
        {

            if (!callbackChannelList.Values.Contains(callback))
            {
                Console.WriteLine("不存在待移除通道");
            }
            else
            {
                lock (SyncObj)
                {
                    callbackChannelList.Remove(callbackChannelList.First(c => c.Value == callback).Key);
                    Console.WriteLine("移除了一个通道");
                }
            }
        }
    }
}
