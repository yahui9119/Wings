using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wings.Domain.Events;
using Wings.Framework.Events;
using Wings.Framework;
using Wings.Framework.Utils;

namespace Wings.Events.Handlers
{
    /// <summary>
    /// 标示发送邮件的时间处理器
    /// </summary>
    [HandlesAsynchronously]
    public class SendEmailHandler : IEventHandler<UserForbiddenEvent>,IEventHandler<UserEnabledEvent>
    {
        /// <summary>
        /// 实例禁用用户事件
        /// </summary>
        /// <param name="evnt"></param>
        public void Handle(UserForbiddenEvent evnt)
        {
            try
            {
                Email.Send(evnt.UserEmail, "【无需回复】您的账号被禁用", string.Format("您的账号已经被管理员禁用，如果您有任何疑问请和管理员联系。{0}", evnt.ForbinddenDate));
            }
            catch (Exception ex)
            {
                Log.Instance.Error(ex);
            }
        }

        public void Handle(UserEnabledEvent evnt)
        {
            try
            {

                Email.Send(evnt.UserEmail, "【无需回复】您的账号已经启用", string.Format("您的账号已经被管理员启用，您可以使用您的账号登录了，如果您有任何疑问请和管理员联系。{0}", evnt.EnableDate));
            }
            catch (Exception ex)
            {
                Log.Instance.Error(ex);
            }
        }
    }
}
