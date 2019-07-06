using System;
using BusinessLogic.Interfaces;
using DomainModels;
using Microsoft.AspNetCore.Mvc;
using TodoWebAPI.GlobalFilter;

namespace TodoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ServiceFilter(typeof(LogTransactionFilter))]
    [ApiController]
    public class ToDosController : BaseController<ToDo>
    {
        public ToDosController(ICRUDBL<ToDo> _crudBLObj) : base(_crudBLObj)
        {
        }

        protected override void UpdateId(Guid? id, ToDo obj)
        {
            obj.Id = id;
        }
    }
}
