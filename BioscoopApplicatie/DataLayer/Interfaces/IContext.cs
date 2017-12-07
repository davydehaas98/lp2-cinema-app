using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Context.Interfaces
{
    public interface IContext<T>
    {
        IQueryable<T> GetAll();
    }
}
