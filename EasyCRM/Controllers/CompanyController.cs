using EasyCRM.BAL.Interface;
using EasyCRM.DAL.Entity.DataModel;
using Microsoft.AspNetCore.Mvc;
using EasyCRM.Models.ViewModels;
using EasyCRM.DAL.Migrations;
using EasyCRM.Models;

namespace EasyCRM.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyService _companyservice;
        private readonly ILogger<CompanyController> _logger;
        public CompanyController(ILogger<CompanyController> logger, ICompanyService companyservice)
        {
            _logger = logger;
            _companyservice = companyservice;
        }
        public async Task<IActionResult> Index(string filter_companyName = "")
        {
            List<CompanyVM> companies = new List<CompanyVM>();

            if (!string.IsNullOrEmpty(filter_companyName))
            {
                companies = await _companyservice.GetCompanyByName(filter_companyName);
            }
            else
                companies = await _companyservice.GetCompanyName();

            return View(companies);
        }
        [HttpPost]
        public async Task<IActionResult> Index(CompanyFilterVM filter)
        {
            List<CompanyVM> companies = new List<CompanyVM>();

            if (!string.IsNullOrEmpty(filter.companyName))
            {
                companies = await _companyservice.GetCompanyByName(filter.companyName);
            }
            else
                companies = await _companyservice.GetCompanyName();

            return View(companies);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> SaveCompany(CompanyVM obj)
        {

            if (obj.CompanyId > 0)
            {
                await _companyservice.UpdateCompany(obj);
            }
            else
            {
                await _companyservice.CreateCompany(obj);
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Add()
        {
            return View();

        }
        public async Task<IActionResult> Edit(int id)
        {
            var company = await _companyservice.GetCompanyById(id);
            return View(company);
        }

        public async Task<IActionResult> Delete(int id)
        {
            //var company = await _companyservice.GetCompanyById(id);
            await _companyservice.DeleteCompany(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
