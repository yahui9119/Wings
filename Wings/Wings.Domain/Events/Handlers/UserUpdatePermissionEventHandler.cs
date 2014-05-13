using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wings.Framework.Events.Bus;

namespace Wings.Domain.Events.Handlers
{
    public class UserUpdatePermissionEventHandler : IDomainEventHandler<UserUpdatePermissionEvent>
    {
        private readonly IEventBus bus;
        public UserUpdatePermissionEventHandler(IEventBus bus)
        {
            this.bus = bus;
        }
        public void Handle(UserUpdatePermissionEvent evnt)
        {
            bus.Publish<UserUpdatePermissionEvent>(evnt);
        }
    }
}
