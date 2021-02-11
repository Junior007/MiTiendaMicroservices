using catalog.data.interfaces;
using catalog.domain.model;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catalog.data.context
{
    class ProductRepository : IProductRepository
    {

        private readonly ICatalogContext _catalogContext;


        public ProductRepository(ICatalogContext catalogContext)
        {
            _catalogContext = catalogContext??throw new ArgumentNullException(nameof(catalogContext));
        }

        public async Task Create(Product product)
        {
            await _catalogContext.Products.InsertOneAsync(product);
        }

        public async Task<bool> Delete(string id)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.ElemMatch(p => p.Id, id);

            DeleteResult deleteResult = await _catalogContext.Products.DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public  async Task<Product> GetProduct(string id)
        {
            return await _catalogContext.Products.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByCategory(string category)
        {
            //return await _catalogContext.Products.Find(p => p.Category ==category).ToListAsync();
            FilterDefinition<Product> filter = Builders<Product>.Filter.ElemMatch(p => p.Category, category);

            return await _catalogContext.Products.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByName(string name)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.ElemMatch(p => p.Name, name);

            return await _catalogContext.Products.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _catalogContext.Products.Find(p=>true).ToListAsync();
        }

        public async Task<bool> Update(Product product)
        {
            var updateResult =  await _catalogContext.Products.ReplaceOneAsync(filter: p=>p.Id==product.Id, replacement: product);


            return updateResult.IsAcknowledged && updateResult.ModifiedCount>0;
        }
    }
}
