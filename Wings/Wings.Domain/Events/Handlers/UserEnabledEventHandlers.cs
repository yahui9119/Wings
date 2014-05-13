using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wings.Domain.Model;
using Wings.Framework.Events.Bus;

namespace Wings.Domain.Events.Handlers
{
    public class UserEnabledEventHandlers : IDomainEventHandler<UserEnabledEvent>
    {
        private readonly IEventBus bus;
        public UserEnabledEventHandlers(IEventBus bus)
        {
            this.bus = bus;
        }
        public void Handle(UserEnabledEvent evnt)
        {
            var user = evnt.Source as User;
            user.Status = Status.Active;
            user.EditDate = DateTime.Now;
            bus.Publish<UserEnabledEvent>(evnt);
        }
    }
}
