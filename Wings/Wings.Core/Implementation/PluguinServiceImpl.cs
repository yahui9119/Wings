using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wings.Contracts;
using Wings.DataObjects;
using Wings.Domain.Model;
using Wings.Domain.Repositories;
using Wings.Domain.Specifications;
using Wings.Framework.Events.Bus;
using Wings.Framework;
using Wings.Framework.Plugin.Contracts;

namespace Wings.Core.Implementation
{
    public class PluginServiceImpl : CoreService, IPluginService
    {
        private readonly IUserRepository userRepository;
        //private readonly IActionRepository actionRepository;

        //private readonly IRoleRepository roleRepository;
        //private readonly IGroupRepository groupRespository;
        //private readonly IModuleRepository moduleRepository;
        private readonly IUserOnlineRepository useronlineRepositoty;
        private readonly IWebRepository webRepository;
        private readonly IEventBus bus;
        public PluginServiceImpl(IRepositoryContext context,
            IUserRepository userRepository,
             IWebRepository webRepository,
            IUserOnlineRepository useronlineRepositoty,
             IEventBus bus
            )
            : base(context)
        {
            this.userRepository = userRepository;
            this.webRepository = webRepository;
            this.useronlineRepositoty = useronlineRepositoty;
            this.bus = bus;
        }




        UserInfo IPluginService.Login(string account, string password, Guid webid)
        {
            var test= useronlineRepositoty.GetAll();
            UserInfo userinfo = null;
            var user = userRepository.Get(Specification<User>.Eval(u => u.Account.Equals(account) && u.Password.Equals(password)));
            if (user != null)
            {
                //user.Forbidden();
                //bus.Commit();
                userinfo = new UserInfo();
                userinfo.Account = user.Account;
                userinfo.RealName = user.RealName;
                userinfo.ID = user.ID;
                user.Online(webid);
                bus.Commit();
                return userinfo;
            }
            return userinfo;
        }

        public List<Permission> GetPermissionByUserID(Guid accountid, Guid webid, bool IsAdmin = false)
        {
            List<Permission> plist = new List<Permission>();
            ModuleDTOList mdtolist = new ModuleDTOList();
            var user = userRepository.Find(Specification<User>.Eval(u => u.Status == Wings.Domain.Model.Status.Active).And(Specification<User>.Eval(u => u.ID.Equals(accountid))));
            if (user == null)
            {
                return plist;
            }
            ModuleDTOList resultmdtolist = new ModuleDTOList();
            if (IsAdmin)
            {
                var web = webRepository.Get(Specification<Web>.Eval(w => w.ID.Equals(webid)));
                if (web != null && web.Modules != null)
                {
                    web.Modules.ForEach(m =>
                        {
                            resultmdtolist.Add(Mapper.Map<Module, ModuleDTO>(m));
                        });
                }
              
            }
            else
            {

                //添加用户组模块
                user.Groups.ForEach(g =>
                {
                    if (g.Status.Equals(Wings.Domain.Model.Status.Active))
                    {
                        g.Modules.ForEach(
                            m =>
                            {
                                mdtolist.Add(Mapper.Map<Module, ModuleDTO>(m));
                            });
                    }
                });
                user.Roles.FindAll(t => t.Status == Wings.Domain.Model.Status.Active).ForEach(r =>
                {
                    r.Modules.FindAll(m => m.Status == Wings.Domain.Model.Status.Active).ForEach(m =>
                    {
                        mdtolist.Add(Mapper.Map<Module, ModuleDTO>(m));
                    });
                });
                user.ModuleAllow.FindAll(m => m.Status == Wings.Domain.Model.Status.Active).ForEach(m =>
                {
                    mdtolist.Add(Mapper.Map<Module, ModuleDTO>(m));
                });
                //去除重复项

                mdtolist.GroupBy(m => m.ID).ToList().ForEach(m =>
                {
                    resultmdtolist.Add(mdtolist.Find(mt => mt.ID == m.Key));
                });
                //去除禁用的
                user.ModuleBan.FindAll(m => m.Status == Wings.Domain.Model.Status.Active).ForEach(m =>
                {
                    //if (resultmdtolist.Contains(Mapper.Map<Module, ModuleDTO>(m)))
                    //{
                    resultmdtolist.RemoveAll(mm => mm.ID.Equals(Mapper.Map<Module, ModuleDTO>(m).ID));
                    //}
                });

            }
            resultmdtolist.ForEach(r => plist.Add(Mapper.Map<ModuleDTO, Permission>(r)));
            return plist;
        }

        public void LoginOut(Guid accountid, Guid webid)
        {
            var user = userRepository.Get(Specification<User>.Eval(u =>u.ID==accountid));
            user.OffLine(webid);
            bus.Commit();
        }

        public void OnlineHeartbeat(Guid accountid, Guid webid)
        {
            
            var user = userRepository.Get(Specification<User>.Eval(u => u.ID == accountid));
            if (user != null)
            {
                user.Online(webid);
                bus.Commit();
            }
        }

        public void Init(Guid webid, List<Permission> permission)
        {
           
        }
    }
}
