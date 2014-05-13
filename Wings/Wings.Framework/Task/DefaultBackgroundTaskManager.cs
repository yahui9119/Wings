using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Wings.Framework.Task
{
    public class DefaultBackgroundTaskManager : IBackgroundTaskManager
    {
        public Timer _timer { get; set; }
        public DefaultBackgroundTaskManager(int min)
        {
            _timer = new Timer(new TimerCallback(Elapsed), null, min, 0);

        }
        public void Elapsed(object state)
        {
            if (!Monitor.TryEnter(_timer))
            {
                return;
            }
            try
            {
                lock (_entries)
                {
                    foreach (var item in _entries)
                    {
                        if ((item.Value.BeginTime.HasValue && item.Value.BeginTime.Value <= DateTime.Now) || (item.Value.EndTime.HasValue && item.Value.EndTime > DateTime.Now))//定时任务
                        {
                            if (item.Value.IsWorking)
                            {
                                //异步调用
                                item.Value.DoWork.BeginInvoke(new AsyncCallback(oneWordEnd), null);
                            }
                            else
                            {
                                Remove(item.Key);
                            }
                        }
                        else
                        {
                            Remove(item.Key);//超时任务 删除
                        }

                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        private void oneWordEnd(object state)
        {
            return;
        }
        private static Dictionary<string, IBackgroundTask> _entries = new Dictionary<string, IBackgroundTask>();
        private static void TryAdd(IBackgroundTask task, string key = null)
        {
            lock (_entries)
            {
                _entries.Add(string.IsNullOrWhiteSpace(key) ? DateTime.Now.ToString() : key, task);
            }
        }
        /// <summary>
        /// 删除一个任务
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool Remove(string key)
        {
            lock (_entries)
            {
                return _entries.Remove(key);
            }
        }
        /// <summary>
        /// 添加一个任务
        /// </summary>
        /// <param name="task"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool Add(IBackgroundTask task, string key)
        {
            if (!_entries.Keys.Contains(key))
            {
                TryAdd(task, key);
                return true;
            }
            return false;
        }
    }
}
