using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Wings.Framework.Task
{
    public interface IBackgroundTaskManager
    {
        Timer _timer { get; set; }
        void Elapsed(object state);
    }
}
