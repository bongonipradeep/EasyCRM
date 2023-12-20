using EasyCRM.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCRM.BAL.Interface
{
    public interface IReportService
    {
        Task<List<ProductReportVM>> GetProductReport();

        Task<List<ProductReportVM>> GetQueryReport();
        Task<List<ProductReportVM>> GetProductReport(string filter_productReport);
    }
}
