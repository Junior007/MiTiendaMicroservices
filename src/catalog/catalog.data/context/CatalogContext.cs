using catalog.domain.interfaces;
using catalog.domain.models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace catalog.domain.context
{
    public class CatalogContext : ICatalogContext
    {
        //private readonly ICatalogDatabaseSettings _catalogDatabaseSettings;
        //private readonly IMongoCollection<Product> _products;

        public CatalogContext(ICatalogDatabaseSettings catalogDatabaseSettings)
        {

            /**
             
             https://stackoverflow.com/questions/38772459/connection-to-mongo-db-using-dotnetcore
             
             */
            /*var builder = new MongoUrlBuilder(catalogDatabaseSettings.ConnectionString);
            var servers = new List<MongoServerAddress>();
            foreach (var server in builder.Servers)
            {
                var address = Dns.GetHostAddresses(server.Host).FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);
                servers.Add(new MongoServerAddress(address.ToString(), server.Port));
            }
            builder.Servers = servers;*/
            /***/
            var client = new MongoClient(catalogDatabaseSettings.ConnectionString);
            //var client = new MongoClient(builder.ToMongoUrl().ToString());
            var database = client.GetDatabase(catalogDatabaseSettings.DatabaseName);
            Products = database.GetCollection< Product>(catalogDatabaseSettings.CollectionName);

            CatalogContextSeed.SeedData(Products);
        }
        public IMongoCollection<Product> Products { get; }
    }
}
