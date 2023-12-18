using EasyCRM.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCRM.BAL.Interface
{
    public interface IStaffService
    {
        Task<List<StaffVM>> GetStaffs();
        Task<StaffVM> GetStaffById(int id);
        Task<bool> CreateStaff(StaffVM staffVM);

        Task<bool> UpdateStaff(StaffVM staffVM);
        Task DeleteStaff(int id);

        Task<List<StaffVM>> GetStaffs(string filter_staffName);
    }
}
