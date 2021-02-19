using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using catalog.application.interfaces;
using catalog.application.models;
using catalog.data.interfaces;

namespace catalog.application.services
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository _productsRepository;
        private readonly IMapper _mapper;
        public ProductsService(IProductsRepository productsRepository, IMapper mapper)
        {
            _productsRepository = productsRepository?? throw new ArgumentNullException(nameof(productsRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Product> Create(Product product)
        {
            var productForCreate = _mapper.Map<domain.models.Product>(product);
            var productCreated = await _productsRepository.Create(productForCreate);
            return _mapper.Map<Product>(productCreated);
        }
        public async Task<bool> Update(Product product)
        {
            var productForUpdate = _mapper.Map<domain.models.Product>(product);
            return await _productsRepository.Update(productForUpdate);
        }
        public async Task<bool> Delete(string id)
        {
            return await _productsRepository.Delete(id);
        }

        public async Task<IEnumerable<Product>>Get()
        {
            var products = await _productsRepository.GetProducts();

            return _mapper.Map<IEnumerable<Product>>(products);

        }

        public async Task<Product> Get(string id)
        {
            var products = await _productsRepository.Get(id);

            return _mapper.Map<Product>(products);
        }

        public async Task<IEnumerable<Product>> GetProductByCategory(string category)
        {
            var products = await _productsRepository.GetProductByCategory(category);

            return _mapper.Map<IEnumerable<Product>>(products);
        }

        public async Task<IEnumerable<Product>> GetProductByName(string name)
        {
            var products = await _productsRepository.GetProductByName(name);

            return _mapper.Map<IEnumerable<Product>>(products);
        }

    }
}
