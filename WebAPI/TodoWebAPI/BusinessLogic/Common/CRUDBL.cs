using AppDBAdapter;
using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Common
{
    public abstract class CRUDBL<T> : ICRUDBL<T>
    {
        private IQueryDB<T> m_DBOperations;

        public CRUDBL(IQueryDB<T> _DBOperations)
        {
            this.m_DBOperations = _DBOperations;
        }

        public Task Delete(Guid id)
        {
            return this.m_DBOperations.Delete(id);
        }

        public Task<List<T>> Get()
        {
            return this.m_DBOperations.Get();
        }

        public Task<T> GetById(Guid id)
        {
            return this.m_DBOperations.GetByID(id);
        }

        public Task Save(T obj)
        {
            if (IsObjectNew(obj))
            {
                return this.m_DBOperations.Insert(obj);
            }
            else
            {
                return this.m_DBOperations.Update(obj);
            }
        }

        protected abstract bool IsObjectNew(T obj);
    }
}
