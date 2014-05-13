using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wings.Framework.Task
{
    /// <summary>
    /// 后台任务接口
    /// </summary>
    public interface IBackgroundTask
    {
        bool IsWorking { get; set; }
        DateTime? BeginTime { get; set; }
        DateTime? EndTime { get; set; }
        Action DoWork { get; set; }
    }
}
