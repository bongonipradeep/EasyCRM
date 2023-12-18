using EasyCRM.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCRM.BAL.Interface
{
    public interface IProductService
    {
        Task<List<ProductVM>> GetProducts();
        Task<ProductVM> GetProductById(int id);
        Task<bool> CreateProduct(ProductVM productVM);

        Task<bool> UpdateProduct(ProductVM productVM);
        Task DeleteProduct(int id);
        Task<List<ProductVM>> GetProducts(string filter_ProductName);
    }
}
