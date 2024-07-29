using ASP.Net_Core_DI_EF_Core_Sql_Product_Homework3.Entities;
using ASP.Net_Core_DI_EF_Core_Sql_Product_Homework3.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASP.Net_Core_DI_EF_Core_Sql_Product_Homework3.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task AddAsync(Product product)
        {
            await _productRepository.AddAsync(product);
        }

        public async Task DeleteAsync(int id)
        {
            await _productRepository.DeleteAsync(id);
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Product product)
        {
            await _productRepository.UpdateAsync(product);
        }
    }
}
