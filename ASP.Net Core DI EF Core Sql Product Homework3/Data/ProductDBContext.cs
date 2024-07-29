using ASP.Net_Core_DI_EF_Core_Sql_Product_Homework3.Entities;
using Microsoft.EntityFrameworkCore;

namespace ASP.Net_Core_DI_EF_Core_Sql_Product_Homework3.Data
{
    public class ProductDBContext : DbContext
    {
        public ProductDBContext(DbContextOptions<ProductDBContext> options) 
        : base(options) { }
        
        public DbSet<Product> Products { get; set; }
        
    }
}
