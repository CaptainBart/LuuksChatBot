using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatHub.Api.Repositories
{
    public abstract class InMemoryRepository<TItem>
    {
        protected InMemoryRepository()
        {
            this.Items = new List<TItem>();
        }

        protected List<TItem> Items { get; }

        public IList<TItem> GetAll()
        {
            return this.Items;
        }

        public void Insert(TItem item)
        {
            this.Items.Add(item);
        }
    }
}