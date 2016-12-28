using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChatHub.Api.Models;

namespace ChatHub.Api.Repositories
{
    public class PostRepository : InMemoryRepository<Post>, IPostRepository
    {
        public PostRepository()
        {

        }
    }
}