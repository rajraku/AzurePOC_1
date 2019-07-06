using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppDBAdapter
{
    public interface IQueryDB<T>
    {
        Task<List<T>> Get();
        Task<T> GetByID(Guid id);
        Task Insert(T obj);
        Task Update(T obj);
        Task Delete(Guid id);
    }
}
