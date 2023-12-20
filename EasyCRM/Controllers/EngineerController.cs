using Microsoft.AspNetCore.Mvc;
using EasyCRM.BAL.Interface;
using EasyCRM.DAL.Entity.DataModel;
using EasyCRM.Models.ViewModels;
using EasyCRM.BAL.Service;
using EasyCRM.Models;

namespace EasyCRM.Controllers
{
    public class EngineerController : Controller
    {
        private readonly IEngineersService _engineersService;
        private readonly ILogger<EngineerController> _logger;
        public EngineerController(ILogger<EngineerController> logger, IEngineersService engineersService)
        {
            _logger = logger;   
            _engineersService = engineersService;   
        }
        public async Task<IActionResult> Index(string filter_engineerName="")
        {
            _logger.LogInformation("FilterEngineer By Engineer...");
            List<EngineerVM> engineers = new List<EngineerVM>();

            if (!string.IsNullOrEmpty(filter_engineerName))
            {
                engineers = await _engineersService.GetEngineers(filter_engineerName);
            }
            else
                engineers = await _engineersService.GetEngineers();

            return View(engineers);
        }
        [HttpPost]
        public async Task<IActionResult> Index(EngineerFilterVM filter)
        {
            _logger.LogInformation("FilterEngineer By Engineer...");
            List<EngineerVM> engineers = new List<EngineerVM>();

            if (!string.IsNullOrEmpty(filter.EngineerName))
            {
                engineers = await _engineersService.GetEngineers(filter.EngineerName);
            }
            else
                engineers = await _engineersService.GetEngineers();

            return View(engineers);
        }
        public async Task<IActionResult> SaveEngineers(EngineerVM obj)
        {
            _logger.LogInformation("Save Engineers...");
            if (obj.EngineerId > 0)
            {
                await _engineersService.UpdateEngineer(obj);
            }
            else
            {
                await _engineersService.CreateEngineer(obj);
            }

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Add()
        {
            _logger.LogInformation("Add Engineers...");
            return View();

        }
        public async Task<IActionResult> Edit(int id)
        {
            _logger.LogInformation("Edit Engineers...");
            var engineer  = await _engineersService.GetEngineerById(id);
            return View(engineer);
        }
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogInformation("Delete Engineers...");
            //var company = await _companyservice.GetCompanyById(id);
            await _engineersService.DeleteEngineer(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
