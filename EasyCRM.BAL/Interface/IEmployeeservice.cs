using EasyCRM.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCRM.BAL.Interface
{
    public interface IEmployeeservice
    {
        Task<List<EmployeeVM>> GetEmployee();
        Task<EmployeeVM> GetEmployeeById(int id);
        Task<bool> CreateEmployee(EmployeeVM employeeVM);

        Task<bool> UpdateEmployee(EmployeeVM employeeVM);
        Task DeleteEmployee(int id);
        Task<List<EmployeeVM>> GetEmployee(string filter_employeename);
    }
}
