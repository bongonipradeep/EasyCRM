using Microsoft.AspNetCore.Mvc;
using EasyCRM.BAL.Interface;
using EasyCRM.DAL.Entity.DataModel;
using EasyCRM.Models.ViewModels;
using EasyCRM.BAL.Service;

namespace EasyCRM.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeservice _employeeservice;  
        private readonly ILogger<EmployeeController> _logger;
        public EmployeeController(ILogger<EmployeeController> logger, IEmployeeservice employeeservice)
         
        {
            _logger = logger;
            _employeeservice = employeeservice;
        }
        public async Task<IActionResult> Index(string filter_employeeName = "")
        {
            List<EmployeeVM> employees = new List<EmployeeVM>();

            if (!string.IsNullOrEmpty(filter_employeeName))
            {
                employees = await _employeeservice.GetEmployee(filter_employeeName);
            }
            else
                employees = await _employeeservice.GetEmployee();

            return View(employees);
        }

        public async Task<IActionResult> SaveEmployee(EmployeeVM obj)
        {

            if (obj.EmployeeId > 0)
            {
                await _employeeservice.UpdateEmployee(obj);
            }
            else
            {
                await _employeeservice.CreateEmployee(obj);
            }

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Add()
        {
            return View();

        }
        public async Task<IActionResult> Edit(int id)
        {
            var employee = await _employeeservice.GetEmployeeById(id);
            return View(employee);
        }
        public async Task<IActionResult> Delete(int id)
        {
            //var company = await _companyservice.GetCompanyById(id);
            await _employeeservice.DeleteEmployee(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
