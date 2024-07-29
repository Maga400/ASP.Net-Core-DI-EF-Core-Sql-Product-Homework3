using ASP.Net_Core_DI_EF_Core_Sql_Product_Homework3.Data;
using ASP.Net_Core_DI_EF_Core_Sql_Product_Homework3.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.Net_Core_DI_EF_Core_Sql_Product_Homework3.Repositories
{
    public class EFProductRepository : IProductRepository
    {
        private readonly ProductDBContext _context;
        public EFProductRepository()
        {
            
        }
        public EFProductRepository(ProductDBContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var product = _context.Products.Where(p => p.Id == id).SingleOrDefault();
            if (product != null) 
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            var result = _context.Products.Where(p => p.Id ==id).SingleOrDefault();
            return result;
        }

        public async Task UpdateAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }
    }
}
