using EasyCRM.DAL.Entity.DataModel;
using EasyCRM.DAL.Interface;
using EasyCRM.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCRM.DAL.Repository
{
    public class EmplyeeRepository : IEmployeeRepository
    {
        private readonly DataContext _context;
        public EmplyeeRepository(DataContext context)
            {
            _context = context;
        }
        public async Task<bool> CreateEmployee(Employee employee)
        {
            await _context.Employes.AddAsync(employee);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task DeleteEmployee(int id)
        {
            Employee employee = await GetEmployeeById(id);
            _context.Employes.Remove(employee);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Employee>> GetEmployee()
        {
            var employes = _context.Employes.AsQueryable();
            return await employes.ToListAsync();
        }

        public async Task<List<Employee>> GetEmployee(string filter_employeeName)
        {
            return await _context.Employes.Where(x => x.EmployeeName.Contains(filter_employeeName)).ToListAsync();
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _context.Employes.FirstOrDefaultAsync(r => r.EmployeeId == id);
        }

        public async Task<bool> UpdateEmployee(Employee employee)
        {
            _context.ChangeTracker.Clear();
            _context.Employes.Update(employee);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
