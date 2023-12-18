using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyCRM.DAL.Entity.DataModel;
using EasyCRM.Models.ViewModels;

namespace EasyCRM.BAL.Interface
{
    public interface ICustomersService
    {
        Task<List<CustomerVM>> GetCustomers();
        Task<CustomerVM> GetCustomerById(int id);
        Task<bool> CreateCustomer(CustomerVM customerVM);

        Task<bool> UpdateCustomer(CustomerVM customerVM);
        Task DeleteCustomer(int id);
        Task<List<CustomerVM>> GetCustomers(string filter_customerName);

    }
}
