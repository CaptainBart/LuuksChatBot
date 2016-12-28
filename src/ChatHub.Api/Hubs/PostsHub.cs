using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using Newtonsoft.Json;

namespace ChatHub.Api.Hubs
{
    public class PostsHub : Hub<IChatClient>
    {
        public PostsHub()
        {
            
        }

        public override Task OnConnected()
        {
            return base.OnConnected();
        }
    }
}