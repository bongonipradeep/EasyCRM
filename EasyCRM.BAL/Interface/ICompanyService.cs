using EasyCRM.DAL.Entity.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyCRM.Models.ViewModels;

namespace EasyCRM.BAL.Interface
{
    public interface ICompanyService
    {
        Task<List<CompanyVM>> GetCompanyName();
        Task<CompanyVM> GetCompanyById(int id);
        Task<bool> CreateCompany(CompanyVM companyVM);

        Task<bool> UpdateCompany(CompanyVM companyVM);
        Task DeleteCompany(int id);
        Task<List<CompanyVM>> GetCompanyByName(string filter_companyName);
    }
}
