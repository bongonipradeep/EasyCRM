using Microsoft.AspNetCore.Mvc;
using EasyCRM.BAL.Interface;
using EasyCRM.DAL.Entity.DataModel;
using EasyCRM.Models.ViewModels;
using EasyCRM.BAL.Service;
using EasyCRM.Models;

namespace EasyCRM.Controllers
{
    public class StaffController : Controller
    {
        private readonly IStaffService _staffService;
        private readonly ILogger<StaffController> _logger;
        public StaffController(ILogger<StaffController> logger, IStaffService staffService)
        {
            _logger = logger;
            _staffService = staffService;
        }
        public async Task<IActionResult> Index(string filter_staffName = "")
        {
            _logger.LogInformation("FilterStaff By Staff...");
            List<StaffVM> staff = new List<StaffVM>();

            if (!string.IsNullOrEmpty(filter_staffName))
            {
                staff = await _staffService.GetStaffs(filter_staffName);
            }
            else
                staff = await _staffService.GetStaffs();

            return View(staff);
        }
        [HttpPost]
        public async Task<IActionResult> Index(StaffFilterVM filter)
        {
            _logger.LogInformation("FilterStaff By Staff...");
            List<StaffVM> staff = new List<StaffVM>();

            if (!string.IsNullOrEmpty(filter.StaffName))
            {
                staff = await _staffService.GetStaffs(filter.StaffName);
            }
            else
                staff = await _staffService.GetStaffs();

            return View(staff);
        }
        public async Task<IActionResult> SaveStaff(StaffVM obj)
        {
            _logger.LogInformation("Save Staff...");

            if (obj.StaffId > 0)
            {
                await _staffService.UpdateStaff(obj);
            }
            else
            {
                await _staffService.CreateStaff(obj);
            }

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Add()
        {
            _logger.LogInformation("Add Staff...");
            return View();

        }
        public async Task<IActionResult> Edit(int id)
        {
            _logger.LogInformation("Edit Staff...");
            var staff  = await _staffService.GetStaffById(id);
            return View(staff);
        }
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogInformation("Delete Staff...");
            //var company = await _companyservice.GetCompanyById(id);
            await _staffService.DeleteStaff(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
