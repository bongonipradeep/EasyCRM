using EasyCRM.DAL.Entity.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCRM.DAL.Interface
{
    public interface ICompanyRepository
    {
        Task<List<Company>> GetCompanies();
        Task<Company> GetCompanyById(int id);
        Task<bool> CreateCompany(Company company);

        Task<bool> UpdateCompany(Company company);
        Task DeleteCompany(int id);
        Task<List<Company>> GetCompanies(string filter_companyName);
    }
}
