using Microsoft.AspNetCore.Mvc;
using EasyCRM.BAL.Service;
using EasyCRM.BAL.Interface;
using EasyCRM.Models.ViewModels;

namespace EasyCRM.Controllers
{
    public class ReportController : Controller
    {
        private readonly IReportService _reportService;
        private readonly ILogger<ReportController> _logger;
        public ReportController(ILogger<ReportController> logger, IReportService reportService) 
        {
            _logger = logger;
            _reportService = reportService;
        }
        public IActionResult Index()
        {
            _logger.LogInformation("Report Page");
            
            return View();
        }

        public async Task<IActionResult> ProductReport(string filter_productReport = "")
        {
            _logger.LogInformation("ProductReport called ");
            List<ProductReportVM> lstobj = new List<ProductReportVM>();
            if(!string.IsNullOrEmpty(filter_productReport)) 
            {
                lstobj = await _reportService.GetProductReport(filter_productReport);
            }
            else
            lstobj = await _reportService.GetProductReport();
            
            return View(lstobj);
        }


        public async Task<IActionResult> QueryReport()
        {
            _logger.LogInformation("QueryReport called ");
            List<ProductReportVM> lstobj = await _reportService.GetQueryReport();
            return View(lstobj);
        }
    }
}
