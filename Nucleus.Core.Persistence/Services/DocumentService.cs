using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Nucleus.Core.Contracts.Collections;
using Nucleus.Core.Contracts.Interfaces;
using Nucleus.Core.Contracts.Models;
using Nucleus.Core.Contracts.Models.DbSettings;
using Nucleus.Core.Contracts.Models.Filters;
using Nucleus.Core.Shared.Persistence.Services.ServiceHelpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nucleus.Core.Persistence.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IMongoCollection<DocumentCollection> _documentsCollection;
        private readonly ProjectionDefinition<DocumentCollection, DocumentModel>? _documentProjection;
        private readonly BsonCollectionBuilder<DocumentModel, DocumentCollection> _documentCollectionBuilder;

        public DocumentService(
            IOptions<DocumentDatabaseSettings> documentDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                documentDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                documentDatabaseSettings.Value.DatabaseName);

            _documentsCollection = mongoDatabase.GetCollection<DocumentCollection>(documentDatabaseSettings.Value.DocumentsCollectionName);
            _documentCollectionBuilder = new BsonCollectionBuilder<DocumentModel, DocumentCollection>();
            _documentProjection = Builders<DocumentCollection>.Projection.Expression(item => new DocumentModel()
            {
                DocumentId = item.DocumentId,
                DocumentName = item.DocumentName,
                DocumentType = item.DocumentType,
                DocumentKey = item.DocumentKey,
                DocumentRepository = item.DocumentRepository,
                DocumentSize = item.documentSize,
                DocumentCategory = item.DocumentCategory,
                CreatedOn = item.CreatedOn
            });
        }

#warning Retire this
        private FilterDefinition<DocumentCollection> GetDocumentsPredicateBuilder(DocumentFilterItem? filterItems)
        {
            // Keeping this business logic in the access layer.  Cannot move it to the business layer yet
            // until I can create an extension that can translate for multiple database.  Moving this to db
            // layer forces you to include mongo drivers which will no longer make this a good solution to be
            // a hybrid database solution just by changing interfaces in the IOC
            var builder = Builders<DocumentCollection>.Filter;
            var filter = builder.Empty;

            // Document Id
            if (!string.IsNullOrWhiteSpace(filterItems?.DocumentId))
                filter &= builder.Where(r => r.DocumentId == filterItems.DocumentId);

            // Document Name
            if (!string.IsNullOrEmpty(filterItems?.DocumentName))
                filter &= builder.Where(r => r.DocumentName == filterItems.DocumentName);

            // Document Key
            if (!string.IsNullOrEmpty(filterItems?.DocumentKey))
                filter &= builder.Where(r => r.DocumentKey == filterItems.DocumentKey);

            // Created on or after
            if (filterItems?.CreatedOnAfter != null)
                filter &= builder.Where(r => r.CreatedOn >= filterItems.CreatedOnAfter);

            // Created on or before
            if (filterItems?.CreatedOnBefore != null)
                filter &= builder.Where(r => r.CreatedOn <= filterItems.CreatedOnBefore);

            return filter;
        }

#warning Retire this
        public async Task<DocumentModel?> GetDocumentAsync(DocumentsFilter filter) =>
            await _documentsCollection.Find(GetDocumentsPredicateBuilder(filter.DocumentsFilters)).Project(_documentProjection).FirstOrDefaultAsync();

#warning Retire this
        public async Task<List<DocumentModel>?> GetDocumentsAsync(DocumentsFilter filter) =>
            await _documentsCollection.Find(GetDocumentsPredicateBuilder(filter.DocumentsFilters)).Project(_documentProjection).ToListAsync();

        public async Task CreateAsync(DocumentModel document) =>
          await _documentsCollection.InsertOneAsync(_documentCollectionBuilder.BuildCollection(document));

        public async Task UpdateAsync(DocumentModel document) =>
            await _documentsCollection.ReplaceOneAsync(x => x.DocumentId == document.DocumentId, _documentCollectionBuilder.BuildCollection(document));

        public async Task RemoveAsync(string id) =>
            await _documentsCollection.DeleteOneAsync(x => x.DocumentId == id);


    }
}
