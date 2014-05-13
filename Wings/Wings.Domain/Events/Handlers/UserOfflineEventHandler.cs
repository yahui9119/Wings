using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wings.Framework.Events.Bus;

namespace Wings.Domain.Events.Handlers
{
    public class UserOfflineEventHandler:IDomainEventHandler<UserOfflineEvent>
    {
        private readonly IEventBus bus;
        public UserOfflineEventHandler(IEventBus bus)
        {
            this.bus = bus;
        }
        public void Handle(UserOfflineEvent evnt)
        {
            bus.Publish<UserOfflineEvent>(evnt);
        }
    }
}
