using Microsoft.AspNetCore.Mvc;
using EasyCRM.BAL.Interface;
using EasyCRM.DAL.Entity.DataModel;
using EasyCRM.Models.ViewModels;
using EasyCRM.BAL.Service;
using EasyCRM.Models;

namespace EasyCRM.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomersService _customersService;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ILogger<CustomerController> logger, ICustomersService customersService)
        {
            _logger = logger;
            _customersService = customersService;
        }
        public async Task<IActionResult> Index(string filter_customerName = "")
        {
            List<CustomerVM> customers = new List<CustomerVM>();

            if (!string.IsNullOrEmpty(filter_customerName))
            {
                customers = await _customersService.GetCustomers(filter_customerName);
            }
            else
                customers = await _customersService.GetCustomers();

            return View(customers);
            
        }
        [HttpPost]
        public async Task<IActionResult> Index(CustomerFilterVM filter)
        {
            List<CustomerVM> customers = new List<CustomerVM>();

            if (!string.IsNullOrEmpty(filter.CustomerName))
            {
                customers = await _customersService.GetCustomers(filter.CustomerName);
            }
            else
                customers = await _customersService.GetCustomers();

            return View(customers);

        }
        [HttpPost]
        public async Task<IActionResult> SaveCustomer(CustomerVM obj)
        {

            if (obj.CustomerId > 0)
            {
                await _customersService.UpdateCustomer(obj);
            }
            else
            {
                await _customersService.CreateCustomer(obj);
            }

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Add()
        {
            return View();

        }
        public async Task<IActionResult> Edit(int id)
        {
            var customer = await _customersService.GetCustomerById(id);
            return View(customer);
        }
        public async Task<IActionResult> Delete(int id)
        {
            //var company = await _companyservice.GetCompanyById(id);
            await _customersService.DeleteCustomer(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
