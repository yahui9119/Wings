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
    /// 用户上下线事件
    /// </summary>
    //[HandlesAsynchronously]
    public class OnOffLineChangeHandler : IEventHandler<UserOnlineEvent>, IEventHandler<UserOfflineEvent>
    {
        /// <summary>
        /// 用户上线
        /// </summary>
        /// <param name="evnt"></param>
        public void Handle(UserOnlineEvent evnt)
        {
            Log.Instance.Info(string.Format("【事件{2}】用户在线[开始]\r\n：用户：{0},站点:{1}", evnt.UserID, evnt.WebID, evnt.ID));
            IUserOnlineRepository useronlineRepository = ServiceLocator.Instance.GetService<IUserOnlineRepository>();
            UserOnline entity = useronlineRepository.Get(Specification<UserOnline>.Eval(uo => uo.user.ID == evnt.UserID).And(Specification<UserOnline>.Eval(uo => uo.web.ID == evnt.WebID)));
            if (entity == null)
            {
                //当前用户未在此站点在线
                useronlineRepository.Add(new UserOnline()
                {
                    CreateDate = DateTime.Now,
                    Creator = null,
                    IsOnline = true,
                    EditDate = DateTime.Now,
                    OnlineTime = DateTime.Now,
                    Status = Status.Active,
                    user = ServiceLocator.Instance.GetService<IUserRepository>().Get(Specification<User>.Eval(u => u.ID == evnt.UserID)),
                    web = ServiceLocator.Instance.GetService<IWebRepository>().Get(Specification<Web>.Eval(u => u.ID == evnt.WebID))
                });
                Log.Instance.Info(string.Format("【事件{0}】当前用户第一次在此站点登录,添加在线记录", evnt.ID));

            }
            else
            {
                entity.IsOnline = true;
                entity.OnlineTime = DateTime.Now;
                useronlineRepository.Update(entity);
                Log.Instance.Info(string.Format("【事件{0}】更新用户在线状态为True", evnt.ID));
            }
            try
            {
                useronlineRepository.Context.Commit();
            }
            catch (Exception ex)
            {

                Log.Instance.Error(string.Format("【事件{0}】", evnt.ID), ex);
            }
           
            Log.Instance.Info(string.Format("【事件{2}】用户在线[结束]\r\n：用户：{0},站点:{1}", evnt.UserID, evnt.WebID, evnt.ID));
        }
        /// <summary>
        /// 用户下线
        /// </summary>
        /// <param name="evnt"></param>
        public void Handle(UserOfflineEvent evnt)
        {
            Log.Instance.Info(string.Format("【事件{2}】用户下线[开始]\r\n：用户：{0},站点:{1}", evnt.UserID, evnt.WebID, evnt.ID));
            IUserOnlineRepository useronlineRepository = ServiceLocator.Instance.GetService<IUserOnlineRepository>();
            UserOnline entity = useronlineRepository.Get(Specification<UserOnline>.Eval(uo => uo.user.ID == evnt.UserID).And(Specification<UserOnline>.Eval(uo => uo.web.ID == evnt.WebID)));
            if (entity == null)
            {
                
                Log.Instance.Error(string.Format("【事件{0}】异常描述：用户没有在线状态，但是用户离线", evnt.ID));

            }
            else
            {
                entity.IsOnline = false;
                entity.OnlineTime = DateTime.Now;
                useronlineRepository.Update(entity);
                Log.Instance.Info(string.Format("【事件{0}】更新用户在线状态为False", evnt.ID));
            }
            try
            {
                useronlineRepository.Context.Commit();
            }
            catch (Exception ex)
            {

                Log.Instance.Error(string.Format("【事件{0}】", evnt.ID), ex);
            }
            Log.Instance.Info(string.Format("【事件{2}】用户下线[结束]\r\n：用户：{0},站点:{1}", evnt.UserID, evnt.WebID, evnt.ID));
        }


    }
}
