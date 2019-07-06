using AppDBAdapter;
using BusinessLogic.Common;
using DomainModels;
using System;

namespace BusinessLogic
{
    public class ToDoBL : CRUDBL<ToDo>
    {
        public ToDoBL(IQueryDB<ToDo> queryDB) : base(queryDB) { }

        protected override bool IsObjectNew(ToDo obj)
        {
            return !obj.Id.HasValue || obj.Id == Guid.Empty;
        }
    }
}
