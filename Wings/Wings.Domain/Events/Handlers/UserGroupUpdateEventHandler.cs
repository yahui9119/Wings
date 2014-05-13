using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wings.Domain.Model;
using Wings.Framework.Events.Bus;

namespace Wings.Domain.Events.Handlers
{

    public class UserGroupUpdateEventHandler : IDomainEventHandler<UserGroupUpdateEvent>
    {

         private readonly IEventBus bus;
         public UserGroupUpdateEventHandler(IEventBus bus)
        {
            this.bus = bus;
        }
        public void Handle(UserGroupUpdateEvent evnt)
        {
            var user = evnt.Source as User;
            evnt.Groups = new Dictionary<Guid, string>();
            user.Groups.ForEach(g =>
            {
                evnt.Groups.Add(g.ID, g.Name);
            });
          
            bus.Publish<UserGroupUpdateEvent>(evnt);
        }
    }
}
