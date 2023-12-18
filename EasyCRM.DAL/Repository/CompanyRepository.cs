using EasyCRM.DAL.Entity;
using EasyCRM.DAL.Entity.DataModel;
using EasyCRM.DAL.Interface;
using EasyCRM.DAL.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCRM.DAL.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly DataContext _context;

        public CompanyRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateCompany(Company company)
        {
           
            await _context.Companies.AddAsync(company);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task DeleteCompany(int id)
        {
            Company company = await GetCompanyById(id);

            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Company>> GetCompanies()
        {
            var companies = _context.Companies.AsQueryable();
            return await companies.ToListAsync();
        }

        public async Task<List<Company>> GetCompanies(string filter_companyName)
        {
            return await   _context.Companies.Where(x => x.CompanyName.Contains(filter_companyName)).ToListAsync();
        }

        public async Task<Company> GetCompanyById(int id)
        {
            //return await _context.Companies.FirstOrDefaultAsync(r => r.CompanyId == id);
            return await _context.Companies.FindAsync(id);
        }

        public  async Task<bool> UpdateCompany(Company company)
        {
            _context.ChangeTracker.Clear();
            _context.Companies.Update(company);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
