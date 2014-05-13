using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wings.Domain.Model;
using Wings.Framework.Events.Bus;

namespace Wings.Domain.Events.Handlers
{
    public class UserForbinddenEventHandlers:IDomainEventHandler<UserForbiddenEvent>
    {
        private readonly IEventBus bus;
        public UserForbinddenEventHandlers(IEventBus bus)
        {
            this.bus = bus;
        }
        public void Handle(UserForbiddenEvent evnt)
        {
            User user = evnt.Source as User;
            user.Status = Status.Forbidden;
            user.EditDate = evnt.ForbinddenDate;
            bus.Publish<UserForbiddenEvent>(evnt);
        }
    }
}
