using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChatHub.Api.Models;

namespace ChatHub.Api.PostReceivers
{
    public interface IPostInterceptor
    {
        void HandlePost(Post post);
    }

    public static class PostInterceptorExtensions
    {
        public static void HandlePost(this IEnumerable<IPostInterceptor> interceptors, Post post)
        {
            foreach (var interceptor in interceptors)
            {
                interceptor.HandlePost(post);
            }
        }
    }
}