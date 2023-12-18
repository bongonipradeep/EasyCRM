using EasyCRM.DAL.Entity;
using EasyCRM.DAL.Entity.DataModel;
using EasyCRM.DAL.Interface;
using EasyCRM.DAL.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCRM.DAL.Repository
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly DataContext _context;

        public CustomersRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateCustomer(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task DeleteCustomer(int id)
        {
            Customer customer = await GetCustomerById(id);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            return await _context.Customers.FirstOrDefaultAsync(r => r.CustomerId == id);
        }

        public async Task<List<Customer>> GetCustomers()
        {
            var customers = _context.Customers.AsQueryable();
            return await customers.ToListAsync();
        }

        public async Task<List<Customer>> GetCustomers(string filter_customerName)
        {
            return await _context.Customers.Where(x => x.CustomerName.Contains(filter_customerName)).ToListAsync();
        }

        public async Task<bool> UpdateCustomer(Customer customer)
        {
            _context.ChangeTracker.Clear();
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
