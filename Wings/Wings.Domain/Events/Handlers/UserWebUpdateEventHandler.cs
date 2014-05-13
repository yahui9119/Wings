using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wings.Domain.Model;
using Wings.Framework.Events.Bus;

namespace Wings.Domain.Events.Handlers
{
    /// <summary>
    /// 用户管理的站点修改了 
    /// </summary>
    public class UserWebUpdateEventHandler : IDomainEventHandler<UserWebUpdateEvent>
    {
        private readonly IEventBus bus;
        public UserWebUpdateEventHandler(IEventBus bus)
        {
            this.bus = bus;
        }
        public void Handle(UserWebUpdateEvent evnt)
        {
            var user = evnt.Source as User;
            evnt.Webs=new Dictionary<Guid,string> ();
            user.Webs.ForEach(w =>
            {
                evnt.Webs.Add(w.ID, w.Name);
            });
           
            
            bus.Publish<UserWebUpdateEvent>(evnt);
        }
    }
}
