using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyCRM.BAL.Interface;
using EasyCRM.DAL.Entity.DataModel;
using EasyCRM.DAL.Interface;
using EasyCRM.DAL.Repository;
using EasyCRM.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace EasyCRM.BAL.Service
{
    public class Employeeservice : IEmployeeservice
    {
        public readonly IEmployeeRepository _employeeRepository;

        public Employeeservice(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        

        public async  Task<bool> CreateEmployee(EmployeeVM employeeVM)
        {
            Employee obj = new Employee()
            {
                EmployeeAddress = employeeVM.EmployeeAddress,
                EmployeeName = employeeVM.EmployeeName,
                EmployeeCity = employeeVM.EmployeeCity,
                EmployeePhone = employeeVM.EmployeePhone
            };
            return await _employeeRepository.CreateEmployee(obj);
        }

        public async  Task DeleteEmployee(int id)
        {
            await _employeeRepository.DeleteEmployee(id);
        }

        public async Task<List<EmployeeVM>> GetEmployee()
        {
            List<Employee> employee = await _employeeRepository.GetEmployee();
            List<EmployeeVM> obj = employee.Select(x => new EmployeeVM()
            {
                EmployeeAddress = x.EmployeeAddress,
                EmployeeName = x.EmployeeName,
                EmployeeCity = x.EmployeeCity,
                EmployeePhone = x.EmployeePhone,
                EmployeeId = x.EmployeeId,
                EmployeeRegion = x.EmployeeRegion,
                EmployeeType = x.EmployeeType
            }).ToList();

            return obj;
        }

        public async Task<List<EmployeeVM>> GetEmployee(string filter_employeename)
        {
            List<Employee> employee = await _employeeRepository.GetEmployee(filter_employeename);
            List<EmployeeVM> obj = employee.Select(x => new EmployeeVM()
            {
                EmployeeAddress = x.EmployeeAddress,
                EmployeeName = x.EmployeeName,
                EmployeeCity = x.EmployeeCity,
                EmployeePhone = x.EmployeePhone,
                EmployeeId = x.EmployeeId,
                EmployeeRegion = x.EmployeeRegion,
                EmployeeType = x.EmployeeType
            }).ToList();

            return obj;
        }

        public async  Task<EmployeeVM> GetEmployeeById(int id)
        {
            Employee employee = await _employeeRepository.GetEmployeeById(id);

            EmployeeVM obj = new EmployeeVM()
            {
            EmployeeAddress = employee.EmployeeAddress,
            EmployeeName = employee.EmployeeName,
            EmployeeCity = employee.EmployeeCity,
            EmployeePhone = employee.EmployeePhone
            
            };
            return obj;
        }

        
        public async Task<bool> UpdateEmployee(EmployeeVM employeeVM)
        {
            Employee obj = new Employee()
            {
                EmployeeAddress = employeeVM.EmployeeAddress,
                EmployeeName = employeeVM.EmployeeName, 
                EmployeeCity = employeeVM.EmployeeCity,
                EmployeePhone = employeeVM.EmployeePhone,
                
            };
            return await _employeeRepository.UpdateEmployee(obj);
        }
    }
}
