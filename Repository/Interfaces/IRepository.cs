using System.Collections.Generic;
using System.Linq;

namespace Repository.Interfaces
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        T GetByID(int id);
    }
}