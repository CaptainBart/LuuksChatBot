using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ChatHub.Api.Hubs;
using ChatHub.Api.Models;
using ChatHub.Api.PostReceivers;
using ChatHub.Api.Repositories;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Infrastructure;

namespace ChatHub.Api.Controllers
{
    public class PostsController : ApiController
    {
        public PostsController(IPostRepository repository, IHubContext<IChatClient> chatClients, IPostInterceptor[] interceptors)
        {
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            
            this.Repository = repository;
            this.Interceptors = interceptors;
            this.ChatClients = chatClients;
        }

        public IPostRepository Repository
        {
            get;
        }

        public IPostInterceptor[] Interceptors
        {
            get;
        }

        public IHubContext<IChatClient> ChatClients { get; }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Post> Get()
        {
            return this.Repository.GetAll();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Post value)
        {
            this.Repository.Insert(value);
            this.ChatClients.Clients.All.publishPost(value);

            this.Interceptors.HandlePost(value);
        }
    }
}