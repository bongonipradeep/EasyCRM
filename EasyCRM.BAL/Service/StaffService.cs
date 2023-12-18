using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyCRM.BAL.Interface;
using EasyCRM.DAL.Entity.DataModel;
using EasyCRM.DAL.Interface;
using EasyCRM.DAL.Repository;
using EasyCRM.Models.ViewModels;

namespace EasyCRM.BAL.Service
{
    public class StaffService : IStaffService   
    {
       private readonly IStaffRepository _staffRepository;

       public StaffService(IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository;
        }

        public async Task<bool> CreateStaff(StaffVM staffVM)
        {
            Staff  obj = new Staff()
            {
                StaffName = staffVM.StaffName,
                StaffAddress = staffVM.StaffAddress,
                StaffCity = staffVM.StaffCity,  
                StaffPhone = staffVM.StaffPhone,    
            };
            return await _staffRepository.CreateStaff(obj);
        }

        public async Task DeleteStaff(int id)
        {
            await _staffRepository.DeleteStaff(id);
        }

        public async Task<StaffVM> GetStaffById(int id)
        {
            Staff staff  = await _staffRepository.GetStaffById(id);

            StaffVM obj = new StaffVM()
            {
               StaffName = staff.StaffName,
               StaffAddress = staff.StaffAddress,       
               StaffPhone= staff.StaffPhone,
               StaffCity= staff.StaffCity,
            };
            return obj;
        }

        public async Task<List<StaffVM>> GetStaffs()
        {
            List<Staff> staff = await _staffRepository.GetStaff();
            List<StaffVM> obj = staff.Select(x => new StaffVM()
            {
                StaffName = x.StaffName,
                StaffAddress = x.StaffAddress,  
                StaffCity = x.StaffCity,
                StaffPhone = x.StaffPhone,
                StaffId= x.StaffId,
            }).ToList();

            return obj;
        }

        public async Task<List<StaffVM>> GetStaffs(string filter_staffName)
        {
            List<Staff> staff = await _staffRepository.GetStaff(filter_staffName);
            List<StaffVM> obj = staff.Select(x => new StaffVM()
            {
                StaffName = x.StaffName,
                StaffAddress = x.StaffAddress,
                StaffCity = x.StaffCity,
                StaffPhone = x.StaffPhone,
                StaffId = x.StaffId,
            }).ToList();

            return obj;
        }

        public async Task<bool> UpdateStaff(StaffVM staffVM)
        {
            Staff obj = new Staff()
            {
                StaffName =staffVM.StaffName,
                StaffAddress =staffVM.StaffAddress,
                StaffCity =staffVM.StaffCity,   
                StaffPhone = staffVM.StaffPhone
            };
            return await _staffRepository.UpdateStaff(obj);
        }
    }
}
