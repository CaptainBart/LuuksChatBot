using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChatHub.Api.Models;

namespace ChatHub.Api.Robots
{
    public class HelloRobot : IRobot
    {
        public string HandlePost(Post post)
        {
            if (!post.Message.StartsWith("hallo", StringComparison.OrdinalIgnoreCase)) return null;
            return $"Hallo {post.Author}";
        }
    }
}