using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyCRM.BAL.Interface;
using EasyCRM.Models.ViewModels;
using EasyCRM.DAL.Interface;
using EasyCRM.DAL.Repository;

namespace EasyCRM.BAL.Service
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;
        public ReportService(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }
        public Task<List<ProductReportVM>> GetProductReport()
        {
            return _reportRepository.GetProductReport();
        }
        public Task<List<ProductReportVM>> GetQueryReport()
        {
            return _reportRepository.GetQueryReport();
        }

        public Task<List<ProductReportVM>> GetProductReport(string filter_ProductReport)
        {
            return _reportRepository.GetProductReport(filter_ProductReport);
        }
    }
}
