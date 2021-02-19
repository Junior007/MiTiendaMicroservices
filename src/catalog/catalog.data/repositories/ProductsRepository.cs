using catalog.data.interfaces;
using catalog.domain.models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catalog.data.repository
{
    public class ProductsRepository : IProductsRepository
    {

        private readonly ICatalogContext _catalogContext;


        public ProductsRepository(ICatalogContext catalogContext)
        {
            _catalogContext = catalogContext??throw new ArgumentNullException(nameof(catalogContext));
        }

        public async Task<Product> Create(Product product)
        {
            await _catalogContext.Products.InsertOneAsync(product);
            return product;
        }

        public async Task<bool> Delete(string id)
        {
            //FilterDefinition<Product> filter = Builders<Product>.Filter.ElemMatch(p => p.Id, id);
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(m => m.Id, id);

            DeleteResult deleteResult = await _catalogContext.Products.DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public  async Task<Product> Get(string id)
        {
            

            return await _catalogContext.Products.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByCategory(string category)
        {
            //return await _catalogContext.Products.Find(p => p.Category ==category).ToListAsync();
            //FilterDefinition<Product> filter = Builders<Product>.Filter.ElemMatch(p => p.Category, category);
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Category, category);
            return await _catalogContext.Products.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByName(string name)
        {
            //FilterDefinition<Product> filter = Builders<Product>.Filter.ElemMatch(p => p.Name, name);
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Name, name);

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
