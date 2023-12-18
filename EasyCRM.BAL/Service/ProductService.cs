using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyCRM.BAL.Interface;
using EasyCRM.DAL.Entity.DataModel;
using EasyCRM.DAL.Interface;
using EasyCRM.DAL.Repository;
using EasyCRM.Models.ViewModels;

namespace EasyCRM.BAL.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<bool> CreateProduct(ProductVM productVM)
        {
            Product  obj = new Product()
            {
                ProductName = productVM.ProductName,
                ProductDescription = productVM.ProductDescription,  
                ProductPrice = productVM.ProductPrice,
                
            };
            return await _productRepository.CreateProduct(obj);
        }

        public async Task DeleteProduct(int id)
        {
            await _productRepository.DeleteProduct(id);
        }

        public async Task<ProductVM> GetProductById(int id)
        {
            Product product = await _productRepository.GetProductById(id);

            ProductVM  obj = new ProductVM()
            {
                ProductName= product.ProductName,
                ProductDescription= product.ProductDescription,
                ProductPrice= product.ProductPrice,

            };
            return obj;
        }

        public async Task<List<ProductVM>> GetProducts()
        {
            List<Product> product  = await _productRepository.GetProduct();
            List<ProductVM> obj = product.Select(x => new ProductVM()
            {
                ProductName = x.ProductName,
                ProductDescription = x.ProductDescription,  
                ProductPrice = x.ProductPrice,
                ProductId = x.ProductId,

            }).ToList();

            return obj;
        }

        public async Task<List<ProductVM>> GetProducts(string filter_ProductName)
        {
            List<Product> product = await _productRepository.GetProduct(filter_ProductName);
            List<ProductVM> obj = product.Select(x => new ProductVM()
            {
                ProductName = x.ProductName,
                ProductDescription = x.ProductDescription,
                ProductPrice = x.ProductPrice,
                ProductId = x.ProductId,

            }).ToList();

            return obj;
        }

        public async Task<bool> UpdateProduct(ProductVM productVM)
        {
            Product obj = new Product()
            {
                ProductName =productVM.ProductName,
                ProductDescription = productVM.ProductDescription,
                ProductPrice = productVM.ProductPrice,

            };
            return await _productRepository.UpdateProduct(obj);
        }
    }
}
