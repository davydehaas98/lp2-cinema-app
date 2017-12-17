using System.Linq;

namespace Context.Interfaces
{
    public interface IContext<T>
    {
        IQueryable<T> GetAll();
        T GetByID(int id);
    }
}
