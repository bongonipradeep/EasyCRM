using EasyCRM.BAL.Interface;
using EasyCRM.DAL.Entity.DataModel;
using EasyCRM.DAL.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyCRM.Models.ViewModels;
using EasyCRM.DAL.Migrations;
using EasyCRM.DAL.Repository;

namespace EasyCRM.BAL.Service
{
    public class CustomersService : ICustomersService
    {
        public readonly ICustomersRepository _customersRepository;
        public CustomersService(ICustomersRepository customersRepository) 
        {
            _customersRepository = customersRepository;
        }
        public async  Task<bool> CreateCustomer(CustomerVM customerVM)
        {
            Customer obj = new Customer()
            {
                CustomerAddress = customerVM.CustomerAddress,
                CustomerName = customerVM.CustomerName,     
                CustomerDescription = customerVM.CustomerDescription,
                CustomerPhone = customerVM.CustomerPhone
            };
            return await _customersRepository.CreateCustomer(obj);
            
        }

        public async Task DeleteCustomer(int id)
        {
            await _customersRepository.DeleteCustomer(id);
        }

        public async Task<CustomerVM> GetCustomerById(int id)
        {
            Customer customer  = await _customersRepository.GetCustomerById(id);

            CustomerVM obj = new CustomerVM()
            {
                CustomerAddress = customer.CustomerAddress,
                CustomerName = customer.CustomerName,
                CustomerDescription = customer.CustomerDescription,
                CustomerPhone = customer.CustomerPhone,
                CustomerId = customer.CustomerId
            };
            return obj;
        }

        public async Task<List<CustomerVM>> GetCustomers()
        {
            List<Customer> customer  = await _customersRepository.GetCustomers();
            List<CustomerVM> obj = customer.Select(x => new CustomerVM()
            {
                CustomerAddress = x.CustomerAddress,
                CustomerName = x.CustomerName,
                CustomerDescription = x.CustomerDescription,
                CustomerPhone = x.CustomerPhone,
                CustomerId = x.CustomerId

            }).ToList();

            return obj;
        }

        public async Task<List<CustomerVM>> GetCustomers(string filter_customerName)
        {
            List<Customer> customer = await _customersRepository.GetCustomers(filter_customerName);
            List<CustomerVM> obj = customer.Select(x => new CustomerVM()
            {
                CustomerAddress = x.CustomerAddress,
                CustomerName = x.CustomerName,
                CustomerDescription = x.CustomerDescription,
                CustomerPhone = x.CustomerPhone,
                CustomerId = x.CustomerId

            }).ToList();

            return obj;
        }

        public async Task<bool> UpdateCustomer(CustomerVM customerVM)
        {
            Customer obj = new Customer()
            {
                CustomerAddress = customerVM.CustomerAddress,
                CustomerName = customerVM.CustomerName,
                CustomerDescription = customerVM.CustomerDescription,
                CustomerPhone = customerVM.CustomerPhone,
                //CompanyId = company   .CompanyId.HasValue ? company.CompanyId.Value:0
                CustomerId = customerVM.CustomerId          };
            return await _customersRepository.UpdateCustomer(obj);
        }
    }
}
