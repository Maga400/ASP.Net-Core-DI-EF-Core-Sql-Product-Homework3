using ASP.Net_Core_DI_EF_Core_Sql_Product_Homework3.Entities;
using ASP.Net_Core_DI_EF_Core_Sql_Product_Homework3.Models;
using ASP.Net_Core_DI_EF_Core_Sql_Product_Homework3.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ASP.Net_Core_DI_EF_Core_Sql_Product_Homework3.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IProductService productService, IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            _productService = productService;
        }
        public async Task<ActionResult> Index()
        {
            var result = await _productService.GetAllAsync();

            var vm = new ProductsViewModel()
            {
                Products = result,
            };
            return View(vm);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var vm = new AddProductViewModel()
            {
                Product = new Product(),
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddProductViewModel vm)
        {
            if (ModelState.IsValid)
            {
                string fileName = null;
                if(vm.Image != null) 
                {
                    string upload = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                    fileName = Guid.NewGuid().ToString() + "-" + vm.Image.FileName;
                    string filePath = Path.Combine(upload, fileName);
                    using (var fileStrem = new FileStream(filePath, FileMode.Create))
                    {
                        vm.Image.CopyTo(fileStrem);
                    }
                }

                vm.Product.ImageLink = fileName;
                await _productService.AddAsync(vm.Product as Product);
                return RedirectToAction("Index");

            }

            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _productService.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            var vm = new UpdateProductViewModel()
            {
                Product = product,

            };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateProductViewModel vm)
        {
            if (ModelState.IsValid)
            {
                string fileName = null;
                if (vm.Image != null)
                {
                    string upload = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                    fileName = Guid.NewGuid().ToString() + "-" + vm.Image.FileName;
                    string filePath = Path.Combine(upload, fileName);
                    using (var fileStrem = new FileStream(filePath, FileMode.Create))
                    {
                        vm.Image.CopyTo(fileStrem);
                    }
                }

                vm.Product.ImageLink = fileName;
                await _productService.UpdateAsync(vm.Product as Product);
                return RedirectToAction("Index");

            }
            return View();

        }

    }
}
