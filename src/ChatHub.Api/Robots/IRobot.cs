using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatHub.Api.Models;

namespace ChatHub.Api.Robots
{
    public interface IRobot
    {
        string HandlePost(Post post);
    }
}
