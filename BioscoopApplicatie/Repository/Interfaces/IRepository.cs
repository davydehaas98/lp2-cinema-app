using System.Linq;

namespace Repository.Interfaces
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();
        T GetByID(int id);
    }
}