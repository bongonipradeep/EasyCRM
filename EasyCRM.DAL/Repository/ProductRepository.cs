using EasyCRM.DAL.Entity;
using EasyCRM.DAL.Entity.DataModel;
using EasyCRM.DAL.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCRM.DAL.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;
        public ProductRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateProduct(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task DeleteProduct(int id)
        {
            Product product = await GetProductById(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Product>> GetProduct()
        {
            var products = _context.Products.AsQueryable();
            return await products.ToListAsync();
        }

        public async Task<List<Product>> GetProduct(string filter_productName)
        {
            return await _context.Products.Where(x => x.ProductName.Contains(filter_productName)).ToListAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(r => r.ProductId == id);
        }
        public async Task<bool> UpdateProduct(Product product)
        {
            _context.ChangeTracker.Clear();
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return true;
        }
    }


}
