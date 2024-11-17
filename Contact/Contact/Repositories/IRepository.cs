using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contact.Repositories
{
    public interface IRepository<T>
    {
        Task<bool> Create(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(int id);
        Task<T> Get(int id);
        Task<IEnumerable<T>> GetAll();
    }
}