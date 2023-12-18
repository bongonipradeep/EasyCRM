using EasyCRM.DAL.Entity.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCRM.DAL.Interface
{
    public interface IStaffRepository
    {
        Task<List<Staff>> GetStaff();
        Task<Staff> GetStaffById(int id);
        Task<bool> CreateStaff(Staff staff);

        Task<bool> UpdateStaff(Staff staff);
        Task DeleteStaff(int id);
        Task<List<Staff>> GetStaff(string filter_staffName);
    }
}
