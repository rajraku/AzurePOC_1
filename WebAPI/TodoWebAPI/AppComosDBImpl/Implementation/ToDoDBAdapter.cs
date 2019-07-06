using CommonModels;
using DomainModels;
using Microsoft.Azure.Documents;
using Microsoft.Extensions.Options;
using System;

namespace AppComosDBImpl.Implementation
{
    public class ToDoDBAdapter : QueryAdapter<ToDo>
    {
        public ToDoDBAdapter(IOptions<CosmosDBConfig> dbConfig) : base("ToDo", dbConfig) { }
    }
}
