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
using Microsoft.Identity.Client;

namespace EasyCRM.BAL.Service
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        public CompanyService(ICompanyRepository companyRepository) 
        {
            _companyRepository = companyRepository;
        }

        public async Task<bool> CreateCompany(CompanyVM companyVM)
        {
            Company obj = new Company()
            {
                CompanyAddress = companyVM.CompanyAddress,
                CompanyName = companyVM.CompanyName,
                CompanyDescription = companyVM.CompanyDescription,
                CompanyPhone = companyVM.CompanyPhone,
               
            };
           return await _companyRepository.CreateCompany(obj);
        }

        public async Task DeleteCompany(int id)
        {
            
            await _companyRepository.DeleteCompany(id);
        }

        public async Task<CompanyVM> GetCompanyById(int id)
        {
            Company company =  await _companyRepository.GetCompanyById(id);

            CompanyVM obj = new CompanyVM()
            {
                CompanyAddress = company.CompanyAddress,
                CompanyName = company.CompanyName,
                CompanyDescription = company.CompanyDescription,
                CompanyPhone = company.CompanyPhone,
                CompanyId = company.CompanyId
            };
            return obj;
        }

        public async Task<List<CompanyVM>> GetCompanyByName(string filter_companyName)
        {
            var company =  await _companyRepository.GetCompanies(filter_companyName);
            List<CompanyVM> obj = company.Select(x => new CompanyVM()
            {
                CompanyAddress = x.CompanyAddress,
                CompanyName = x.CompanyName,
                CompanyDescription = x.CompanyDescription,
                CompanyPhone = x.CompanyPhone,
                CompanyId = x.CompanyId

            }).ToList();

            return obj;
        }

        public async Task<List<CompanyVM>> GetCompanyName()
        {
            List<Company> company = await _companyRepository.GetCompanies();
            List<CompanyVM> obj = company.Select(x => new CompanyVM()
            {
                CompanyAddress = x.CompanyAddress,
                CompanyName = x.CompanyName,
                CompanyDescription = x.CompanyDescription,
                CompanyPhone = x.CompanyPhone,
                CompanyId = x.CompanyId

            }).ToList();
            
            return obj;
        }

        public async Task<bool> UpdateCompany(CompanyVM companyVM)
        {
            Company obj = new Company()
            {
                CompanyAddress = companyVM.CompanyAddress,
                CompanyName = companyVM.CompanyName,
                CompanyDescription = companyVM.CompanyDescription,
                CompanyPhone = companyVM.CompanyPhone,
                //CompanyId = company   .CompanyId.HasValue ? company.CompanyId.Value:0
                CompanyId = companyVM.CompanyId ?? 0
            };
            return await _companyRepository.UpdateCompany(obj);
        }
    }
}
