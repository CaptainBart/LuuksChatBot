using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChatHub.Api.Hubs;
using ChatHub.Api.Models;
using ChatHub.Api.PostReceivers;
using Microsoft.AspNet.SignalR;

namespace ChatHub.Api.Robots
{
    public class RobotPostInterceptor : IPostInterceptor
    {
        private IHubContext<IChatClient> _chatClients;
        private IRobot[] _robots;

        public RobotPostInterceptor(IHubContext<IChatClient> chatClients, IRobot[] robots)
        {
            _chatClients = chatClients;
            _robots = robots;
        }
        public void HandlePost(Post post)
        {
            foreach (var robot in _robots)
            {
                string answer = robot.HandlePost(post);
                if (!String.IsNullOrEmpty(answer))
                {
                    var reply = new Post()
                    {
                        Author = "Robot",
                        CreatedOn = DateTime.Now,
                        Message = answer
                    };

                    _chatClients.Clients.All.publishPost(reply);
                }
            }
        }
    }
}