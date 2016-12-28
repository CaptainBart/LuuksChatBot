using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatHub.Api.Repositories
{
    public interface IRepository<TItem>
    {
        IList<TItem> GetAll();
        void Insert(TItem item);
    }
}
