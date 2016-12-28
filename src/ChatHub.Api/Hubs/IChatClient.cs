using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatHub.Api.Models;
using Microsoft.AspNet.SignalR.Hubs;

namespace ChatHub.Api.Hubs
{
    public interface IChatClient
    {
        void publishPost(Post post);
    }
}
