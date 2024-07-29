using ASP.Net_Core_DI_EF_Core_Sql_Product_Homework3.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASP.Net_Core_DI_EF_Core_Sql_Product_Homework3.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetAllAsync();
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(int id);
        Task<Product> GetByIdAsync(int id);
        
    }
}
