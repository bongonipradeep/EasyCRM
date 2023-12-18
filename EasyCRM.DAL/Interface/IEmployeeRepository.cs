using EasyCRM.DAL.Entity.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCRM.DAL.Interface
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetEmployee();
        Task<Employee> GetEmployeeById(int id);
        Task<bool> CreateEmployee(Employee employee);

        Task<bool> UpdateEmployee(Employee employee);
        Task DeleteEmployee(int id);
        Task<List<Employee>> GetEmployee(string filter_employeeName);
    }
}
