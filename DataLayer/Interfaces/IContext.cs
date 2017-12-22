using System.Collections.Generic;
using System.Linq;

namespace Context.Interfaces
{
    public interface IContext<T>
    {
        List<T> GetAll();
        T GetByID(int id);
    }
}
