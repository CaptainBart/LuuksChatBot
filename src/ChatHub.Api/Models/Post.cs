using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatHub.Api.Models
{
    public class Post
    {
        public string Author { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Message { get; set; }
    }
}