using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyCRM.Models.ViewModels;

namespace EasyCRM.DAL.Interface
{
    public interface IReportRepository
    {
        Task <List<ProductReportVM>> GetProductReport();

         Task<List<ProductReportVM>> GetQueryReport();
        Task<List<ProductReportVM>> GetProductReport(string filter_productReport);
       

    }
}
