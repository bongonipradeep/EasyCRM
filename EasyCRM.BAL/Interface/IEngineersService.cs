using EasyCRM.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCRM.BAL.Interface
{
    public interface IEngineersService
    {
        Task<List<EngineerVM>> GetEngineers();
        Task<EngineerVM> GetEngineerById(int id);
        Task<bool> CreateEngineer(EngineerVM engineerVM);

        Task<bool> UpdateEngineer(EngineerVM engineerVM);
        Task DeleteEngineer(int id);

        Task<List<EngineerVM>> GetEngineers(string filter_engineerName);
    }
}
