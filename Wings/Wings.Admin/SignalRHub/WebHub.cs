using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace Wings.Admin.SignalRHub
{
    public class WebHub : Hub
    {
        public void Hello1(string message)
        {
            Clients.All.hello(message);
        }
        public void send(string message)
        {
            Clients.All.hello(message);
        }
    }
}