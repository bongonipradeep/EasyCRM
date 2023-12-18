using EasyCRM.DAL.Entity.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCRM.DAL.Interface
{
    public interface IEngineersrepository
    {
        Task<List<Engineer>> GetEngineer();
        Task<Engineer> GetEngineerById(int id);
        Task<bool> CreateEngineer(Engineer engineer);

        Task<bool> UpdateEngineer(Engineer engineer);
        Task DeleteEngineer(int id);
        Task<List<Engineer>> GetEngineer(string filter_engineerName);
    }
}
