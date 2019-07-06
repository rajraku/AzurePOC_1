using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppDBAdapter;
using CommonModels;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Extensions.Options;

namespace AppComosDBImpl
{
    public abstract class QueryAdapter<T> : IQueryDB<T>
    {
        private string m_CollectionName;
        private string m_DocumentDBName;

        DocumentClient m_docClient;

        public QueryAdapter(string _collectionName,
                            IOptions<CosmosDBConfig> dbConfig)
        {
            this.m_CollectionName = _collectionName;
            this.m_docClient = new DocumentClient(new Uri(dbConfig.Value.EndPointURL), dbConfig.Value.PrimaryKey);
            this.m_DocumentDBName = dbConfig.Value.DocumentDBName;
        }

        public async Task Delete(Guid id)
        {
            await InitializeDB();
            var docCollection = await this.m_docClient.DeleteDocumentAsync(UriFactory.CreateDocumentUri(this.m_DocumentDBName, this.m_CollectionName, id.ToString()));
            
        }

        public async Task<List<T>> Get()
        {
            // Set some common query options
            FeedOptions queryOptions = new FeedOptions { MaxItemCount = -1 };

            await InitializeDB();
            IQueryable<T> docQuery = this.m_docClient.CreateDocumentQuery<T>(UriFactory.CreateDocumentCollectionUri(this.m_DocumentDBName, this.m_CollectionName), queryOptions);
            
            return docQuery?.ToList<T>();
        }

        public async Task<T> GetByID(Guid id)
        {
            await InitializeDB();
            return await this.m_docClient.ReadDocumentAsync<T>(UriFactory.CreateDocumentUri(this.m_DocumentDBName, this.m_CollectionName, id.ToString()));
        }

        public async Task Insert(T obj)
        {
            await InitializeDB();
            await this.m_docClient.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(this.m_DocumentDBName, this.m_CollectionName), obj);
        }

        public async Task Update(T obj)
        {
            await InitializeDB();
            await this.m_docClient.UpsertDocumentAsync(UriFactory.CreateDocumentCollectionUri(this.m_DocumentDBName, this.m_CollectionName), obj);
        }

        private async Task InitializeDB()
        {
            await this.m_docClient.CreateDatabaseIfNotExistsAsync(new Database { Id = this.m_DocumentDBName });
            await this.m_docClient.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri(this.m_DocumentDBName), new DocumentCollection { Id = this.m_CollectionName });
        }

    }
}
