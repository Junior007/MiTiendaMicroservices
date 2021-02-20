using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using catalog.domain.models;

namespace catalog.domain.interfaces
{
    public interface IProductsRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> Get(string id);
        Task<IEnumerable<Product>> GetProductByName(string name);
        Task<IEnumerable<Product>> GetProductByCategory(string category);
        Task<Product> Create(Product product);
        Task<bool> Update(Product product);
        Task<bool> Delete(string id);


    }
}
