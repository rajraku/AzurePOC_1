using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace TodoWebAPI.Controllers
{
    public abstract class BaseController<T> : ControllerBase
    {
        private ICRUDBL<T> m_crudBL { get; set; }
        protected abstract void UpdateId(Guid? id, T obj);

        protected BaseController(ICRUDBL<T> _crudBLObj)
        {
            m_crudBL = _crudBLObj;
        }

        // GET: api/Base
        [HttpGet]
        public async Task<IEnumerable<T>> Get()
        {
            return await m_crudBL.Get();
        }

        // GET: api/Base/Guid
        [HttpGet("{id}", Name = "Get")]
        public async Task<T> Get(Guid id)
        {
            return await m_crudBL.GetById(id);
        }

        // POST: api/Base
        [HttpPost]
        public async Task Post([FromBody] T obj)
        {
            UpdateId(null, obj);
            await m_crudBL.Save(obj);
        }

        // PUT: api/Base/5
        [HttpPut("{id}")]
        public async Task Put(Guid id, [FromBody] T obj)
        {
            UpdateId(id, obj);
            await m_crudBL.Save(obj);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await m_crudBL.Delete(id);
        }
    }
}
