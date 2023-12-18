using EasyCRM.DAL.Entity.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCRM.DAL.Interface
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProduct();
        Task<Product> GetProductById(int id);
        Task<bool> CreateProduct(Product product);

        Task<bool> UpdateProduct(Product product);
        Task DeleteProduct(int id);
        Task<List<Product>> GetProduct(string filter_productName);
    }
}
