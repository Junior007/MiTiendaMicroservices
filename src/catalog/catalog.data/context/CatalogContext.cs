using catalog.data.interfaces;
using catalog.domain.model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catalog.data.context
{
    public class CatalogContext : ICatalogContext
    {
        private readonly ICatalogDatabaseSettings _catalogDatabaseSettings;
        //private readonly IMongoCollection<Product> _products;

        public CatalogContext(ICatalogDatabaseSettings catalogDatabaseSettings)
        {
            var client = new MongoClient(catalogDatabaseSettings.ConnectionString);
            var database = client.GetDatabase(catalogDatabaseSettings.DatabaseName);
            Products = database.GetCollection< Product>(catalogDatabaseSettings.CollectionName);

            CatalogContextSeed.SeedData(Products);
        }
        public IMongoCollection<Product> Products { get; }
    }
}
