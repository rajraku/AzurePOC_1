using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface ICRUDBL<T>
    {
        Task<List<T>> Get();
        Task<T> GetById(Guid id);
        Task Save(T obj);
        Task Delete(Guid id);
    }
}
