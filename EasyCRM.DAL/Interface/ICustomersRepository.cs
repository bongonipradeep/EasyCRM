using EasyCRM.DAL.Entity.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCRM.DAL.Interface
{
    public interface ICustomersRepository
    {
        Task<List<Customer>> GetCustomers();
        Task<Customer> GetCustomerById(int id);
        Task<bool> CreateCustomer(Customer customer);

        Task<bool> UpdateCustomer(Customer customer);
        Task DeleteCustomer(int id );
        Task<List<Customer>> GetCustomers(string filter_customerName);
    }
}
