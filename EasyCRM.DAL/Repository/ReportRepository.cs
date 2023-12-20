using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyCRM.DAL.Entity;
using EasyCRM.DAL.Entity.DataModel;
using EasyCRM.DAL.Interface;
using EasyCRM.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace EasyCRM.DAL.Repository
{
    public class ReportRepository : IReportRepository
    {
        private readonly DataContext _context;

        public ReportRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<List<ProductReportVM>> GetProductReport()
        {

            //var 
             var  vm =  _context.CustomerEnquiries
                 .Include(x => x.Product)
                 .Include(x => x.Company)
                 .Include(x => x.Customer)
                 .Select(x => new ProductReportVM()
                 {
                     companyName = x.Company.CompanyName,
                     productName = x.Product.ProductName,
                     customerName = x.Customer.CustomerName
                 }
                 ).AsQueryable();
            return await vm.ToListAsync();
        }
        public async Task<List<ProductReportVM>> GetQueryReport()
        {
            var vm = _context.CustomerEnquiries
                .Include(x => x.Product)
                .Include(x => x.Company)
                .Include(x => x.Customer)
                .Select(x => new ProductReportVM()
                {
                    companyName = x.Company.CompanyName,
                    productName = x.Product.ProductName,
                    customerName = x.Customer.CustomerName,
                    QueryDescription = x.QueryDescription

                }
                ).AsQueryable();
            return await vm.ToListAsync();
        }

        public async Task<List<ProductReportVM>> GetProductReport(string filter_productReport)
        {
            var vm = _context.CustomerEnquiries
                .Include(x => x.Product)
                .Include(x => x.Company)
                .Include(x => x.Customer)
                .Select(x => new ProductReportVM()
                {
                    companyName = x.Company.CompanyName,
                    productName = x.Product.ProductName,
                    customerName = x.Customer.CustomerName
                }
                ).Where(x => x.productName.Contains(filter_productReport)).AsQueryable();
            return await vm.ToListAsync();
        }
    }
}
