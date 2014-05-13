using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wings.Domain.Model;

namespace Wings.Domain.Events
{
    [Serializable]
    public class UserGroupUpdateEvent : DomainEvent
    {
          public UserGroupUpdateEvent() { }
          public UserGroupUpdateEvent(IEntity source) : base(source) { }
          public string UserName { get; set; }
          public Guid UserID { get; set; }
          public string Email { get; set; }
          public Dictionary<Guid, string> Groups { get; set; }
          public DateTime UpdateTime { get; set; }

    }
}
