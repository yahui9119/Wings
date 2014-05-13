using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wings.Domain.Model;
using Wings.Framework.Events.Bus;

namespace Wings.Domain.Events.Handlers
{
    public class UserRoleUpdateEventHandler : IDomainEventHandler<UserRoleUpdateEvent>
    {

        private readonly IEventBus bus;

        public UserRoleUpdateEventHandler(IEventBus bus)
        {
            this.bus = bus;
        }
        public void Handle(UserRoleUpdateEvent evnt)
        {
            var user = evnt.Source as User;
            evnt.Roles = new Dictionary<Guid, string>();
            user.Roles.ForEach(r =>
            {
                evnt.Roles.Add(r.ID, r.Name);
            });
         
            bus.Publish<UserRoleUpdateEvent>(evnt);
        }
    }
}
