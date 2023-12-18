using Microsoft.AspNetCore.Mvc;
using EasyCRM.BAL.Interface;
using EasyCRM.DAL.Entity.DataModel;
using EasyCRM.Models.ViewModels;
using EasyCRM.BAL.Service;

namespace EasyCRM.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductController> _logger;
        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }
        public async Task<IActionResult> Index(string filter_productName = "")
        {
            List<ProductVM> products = new List<ProductVM>();

            if (!string.IsNullOrEmpty(filter_productName))
            {
                products = await _productService.GetProducts(filter_productName);
            }
            else
                products = await _productService.GetProducts();

            return View(products);
        }

        public async Task<IActionResult> SaveProductd(ProductVM obj)
        {

            if (obj.ProductId > 0)
            {
                await _productService.UpdateProduct(obj);
            }
            else
            {
                await _productService.CreateProduct(obj);
            }

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Add()
        {
            return View();

        }
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productService.GetProductById(id);
            return View(product);
        }
        public async Task<IActionResult> Delete(int id)
        {
            //var company = await _companyservice.GetCompanyById(id);
            await _productService.DeleteProduct(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
