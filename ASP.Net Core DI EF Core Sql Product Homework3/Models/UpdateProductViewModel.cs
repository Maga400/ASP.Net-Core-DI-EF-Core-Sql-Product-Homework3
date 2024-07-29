using ASP.Net_Core_DI_EF_Core_Sql_Product_Homework3.Entities;
using Microsoft.AspNetCore.Http;

namespace ASP.Net_Core_DI_EF_Core_Sql_Product_Homework3.Models
{
    public class UpdateProductViewModel
    {
        public Product Product { get; set; }
        public IFormFile Image { get; set; }
        public UpdateProductViewModel()
        {
        }

    }
}