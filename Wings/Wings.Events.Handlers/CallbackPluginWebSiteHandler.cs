using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wings.Domain.Events;
using Wings.Domain.Model;
using Wings.Domain.Repositories;
using Wings.Domain.Specifications;
using Wings.Framework;
using Wings.Framework.Events;
using Wings.Framework.Plugin.Contracts;
using Wings.Framework.Plugin.Utils;

namespace Wings.Events.Handlers
{
    /// <summary>
    /// 回调扩展站点事件
    /// </summary>
    public class CallbackPluginWebSiteHandler : IEventHandler<UserUpdatePermissionEvent>
    {
        /// <summary>
        /// 更新用户的权限
        /// </summary>
        /// <param name="evnt"></param>
        public void Handle(UserUpdatePermissionEvent evnt)
        {
            Log.Instance.Info(string.Format("【事件{2}】更新用户站点权限[开始]\r\n用户：{0},站点:{1}", evnt.UserID, evnt.WebID, evnt.ID));
            IUserOnlineRepository useronlineRepository = ServiceLocator.Instance.GetService<IUserOnlineRepository>();
            UserOnline entity = useronlineRepository.Get(Specification<UserOnline>.Eval(uo => uo.user.ID == evnt.UserID).And(Specification<UserOnline>.Eval(uo => uo.web.ID == evnt.WebID)).And(Specification<UserOnline>.Eval(uo => uo.IsOnline == true)));
            if (entity == null)
            {
                //当前用户未在此站点在线
                Log.Instance.Info(string.Format("【事件{0}】当前用户未在此站点在线，更新失败", evnt.ID));
                return;
            }
            var channel = ChannelManager.Instance.Get(evnt.WebID);
            if (channel == null)
            {
                //当前用户在此站点信息管道丢失
                Log.Instance.Info(string.Format("【事件{0}】当前用户在此站点信息管道丢失,更新失败", evnt.ID));
                return;
            }
            IPluginService pluginServiceImpl = ServiceLocator.Instance.GetService<IPluginService>();
            channel.SavePermission(pluginServiceImpl.GetPermissionByUserID(evnt.UserID,evnt.WebID), evnt.UserID);
            Log.Instance.Info(string.Format("【事件{2}】更新用户站点权限[结束]\r\n用户：{0},站点:{1}", evnt.UserID, evnt.WebID, evnt.ID));
        }
    }
}
