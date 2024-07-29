using ASP.Net_Core_DI_EF_Core_Sql_Product_Homework3.Entities;
using System.Collections.Generic;

namespace ASP.Net_Core_DI_EF_Core_Sql_Product_Homework3.Models
{
    public class ProductsViewModel
    {
        public List<Product> Products { get; set; }
        public ProductsViewModel()
        {
        }

    }
}